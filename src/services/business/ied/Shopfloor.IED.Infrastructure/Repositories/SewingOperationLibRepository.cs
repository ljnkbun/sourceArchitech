using AutoMapper;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;
using System.Data;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingOperationLibRepository : MasterRepositoryAsync<SewingOperationLib>, ISewingOperationLibRepository
    {
        private readonly DbSet<SewingOperationLib> _dbSet;
        private readonly DbSet<AutoIncrement> _autoIncrementSet;
        public SewingOperationLibRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbSet = _dbContext.Set<SewingOperationLib>();
            _autoIncrementSet = _dbContext.Set<AutoIncrement>();
        }
        public async Task<SewingOperationLib> GetSewingOperationLibByIdAsync(int id)
        {
            return await _dbContext.Set<SewingOperationLib>()
                            .AsNoTracking()
                            .Include(s => s.SewingOperationLibBOLs.OrderBy(r => r.LineNumber))
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingOperationLibAsync(SewingOperationLib entity, ICollection<SewingOperationLibBOL> bols)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingOperationLibBOL>().Where(s => s.SewingOperationLibId == entity.Id).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingOperationLibResult>().Where(s => s.SewingOperationLibId == entity.Id).ExecuteDeleteAsync();

                    if (bols.Any())
                    {
                        await _dbContext.Set<SewingOperationLibBOL>().AddRangeAsync(bols);
                        var entities = GenerateSewingOperationLibResultAsync(entity, bols);
                        await _dbContext.Set<SewingOperationLibResult>().AddRangeAsync(entities);
                    }

                    _dbContext.Set<SewingOperationLib>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex, ex.Message);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }

        private List<SewingOperationLibResult> GenerateSewingOperationLibResultAsync(SewingOperationLib operation, ICollection<SewingOperationLibBOL> operationLibBOLs)
        {
            if (!operationLibBOLs.Any())
                return new List<SewingOperationLibResult>();

            int ratioTMUPerMinute = 2000;
            var personalAllowance = operation.PersonalAllowance / 100;
            var contingency = operation.Contingency / 100;
            var delay = operation.MachineDelay / 100;

            var sumTaskManualTMU = operationLibBOLs.Where(b => b.Type == OperationBOLType.CO).Sum(b => ParseExpressionToDecimal(b.Freq) * (b.ManualTMU ?? 0));
            var sumTaskMachineTMU = operationLibBOLs.Where(b => b.Type == OperationBOLType.MN).Sum(b => ParseExpressionToDecimal(b.Freq) * (b.MachineTMU ?? 0));
            var sumTaskBundleTMU = operationLibBOLs.Where(b => b.Type == OperationBOLType.BU).Sum(b => ParseExpressionToDecimal(b.Freq) * (b.BundleTMU ?? 0));

            var macros = operationLibBOLs.Where(b => b.Type == OperationBOLType.MC);
            if (macros.Any())
            {
                var manualTMUInMacro = macros.Sum(b => ParseExpressionToDecimal(b.Freq) * (b.ManualTMU ?? 0));
                var machineTMUInMacro = macros.Sum(b => ParseExpressionToDecimal(b.Freq) * (b.MachineTMU ?? 0));
                var bundleTMUInMacro = macros.Sum(b => ParseExpressionToDecimal(b.Freq) * (b.BundleTMU ?? 0));
                sumTaskManualTMU += manualTMUInMacro;
                sumTaskMachineTMU += machineTMUInMacro;
                sumTaskBundleTMU += bundleTMUInMacro;
            }

            sumTaskManualTMU = RoundOne(sumTaskManualTMU);
            sumTaskMachineTMU = RoundOne(sumTaskMachineTMU);
            sumTaskBundleTMU = RoundOne(sumTaskBundleTMU);

            var manualBasicMinute = Round(sumTaskManualTMU / ratioTMUPerMinute);
            var machineBasicMinute = Round(sumTaskMachineTMU / ratioTMUPerMinute);
            var bundleBasicMinute = Round(sumTaskBundleTMU / ratioTMUPerMinute);

            var manualPersonalAllowance = Round(manualBasicMinute * personalAllowance);
            var machinePersonalAllowance = Round(machineBasicMinute * personalAllowance);
            var bundlePersonalAllowance = Round(bundleBasicMinute * personalAllowance);

            var machineDelay = Round(machineBasicMinute * delay);

            var totalManual = Round(manualBasicMinute + manualPersonalAllowance);
            var totalMachine = Round(machineBasicMinute + machinePersonalAllowance + machineDelay);
            var totalBundle = Round(bundleBasicMinute + bundlePersonalAllowance);

            var manualType = new SewingOperationLibResult()
            {
                SewingOperationLibId = operation.Id,
                Type = ResultType.Manual,
                TMU = sumTaskManualTMU,
                BasicMinute = manualBasicMinute,
                PersonalAllowance = manualPersonalAllowance,
                MachineDelay = null,
                Total = totalManual,
                Contingency = Round(totalManual * contingency)
            };
            var machineType = new SewingOperationLibResult()
            {
                SewingOperationLibId = operation.Id,
                Type = ResultType.Machine,
                TMU = sumTaskMachineTMU,
                BasicMinute = machineBasicMinute,
                PersonalAllowance = machinePersonalAllowance,
                MachineDelay = machineDelay,
                Total = totalMachine,
                Contingency = Round(totalMachine * contingency)
            };
            var bundleType = new SewingOperationLibResult()
            {
                SewingOperationLibId = operation.Id,
                Type = ResultType.Bundle,
                TMU = sumTaskBundleTMU,
                BasicMinute = bundleBasicMinute,
                PersonalAllowance = bundlePersonalAllowance,
                MachineDelay = null,
                Total = totalBundle,
                Contingency = Round(totalBundle * contingency)
            };

            var total = Round(manualType.Total + machineType.Total + bundleType.Total);
            var totalcontingency = Round(manualType.Contingency + machineType.Contingency + bundleType.Contingency);
            var totalType = new SewingOperationLibResult()
            {
                SewingOperationLibId = operation.Id,
                Type = ResultType.Total,
                TMU = Round(manualType.TMU + machineType.TMU + bundleType.TMU),
                BasicMinute = Round(manualType.BasicMinute + machineType.BasicMinute + bundleType.BasicMinute),
                PersonalAllowance = Round(manualType.PersonalAllowance + machineType.PersonalAllowance + bundleType.PersonalAllowance),
                MachineDelay = machineType.MachineDelay,
                Total = total,
                Contingency = totalcontingency,
                SMV = Round(total + totalcontingency)
            };

            var entities = new List<SewingOperationLibResult>
            {
                manualType,
                machineType,
                bundleType,
                totalType
            };
            return entities;
        }
        private static decimal ParseExpressionToDecimal(string expression)
        {
            if (expression.IsNullOrEmpty())
                return 0;

            try
            {
                string result = new DataTable().Compute(expression, null).ToString();
                return decimal.Parse(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                throw new ApiException($"Parse Freq: {expression} to Number failed.");
            }
        }
        private static decimal RoundOne(decimal number)
        {
            return Math.Round(number, 1, MidpointRounding.AwayFromZero);
        }
        private static decimal Round(decimal number)
        {
            return Math.Round(number, 4, MidpointRounding.AwayFromZero);
        }

        public async Task<SewingOperationLib> AddSewingOperationLibAsync(SewingOperationLib entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                var componentCode = await _dbContext.Set<SewingComponent>().FirstOrDefaultAsync(c => c.Id == entity.SewingComponentId).Select(c => c.Code);
                if (componentCode == null)
                    throw new ApiException($"SewingComponent with Id {entity.SewingComponentId} not found.");
                try
                {
                    entity.Code = await GenerateCodeAsync(entity.SubCategoryCode, componentCode);
                    await _dbSet.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();

                    if (entity.SewingOperationLibBOLs.Any())
                    {
                        var results = GenerateSewingOperationLibResultAsync(entity, entity.SewingOperationLibBOLs);
                        await _dbContext.Set<SewingOperationLibResult>().AddRangeAsync(results);
                    }

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return entity;
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex, ex.Message);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }

        private async Task<string> GenerateCodeAsync(string subCategoryCode, string componentCode)
        {
            var operationAutoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Operation);
            if (operationAutoIncrement == null)
                throw new ApiException("AutoIncrement with type Operation is not found.");
            string inputValue = $"{subCategoryCode}{operationAutoIncrement.Separate}{componentCode}";

            var autoIncrement = await InsertAutoIncrementIfNotExistAsync(inputValue);
            string newCode = "";
            bool isUnique = false;
            int count = 0;
            do
            {
                newCode = AutoIncrementHelper.GetNewCode(inputValue, autoIncrement);
                isUnique = await _dbSet.AllAsync(x => x.Code != newCode);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _autoIncrementSet.Update(autoIncrement);
            return newCode;
        }
        private async Task<AutoIncrement> InsertAutoIncrementIfNotExistAsync(string inputValue)
        {
            var autoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Operation && x.InputValue == inputValue);
            if (autoIncrement != null)
                return autoIncrement;

            var entity = new AutoIncrement()
            {
                Type = AutoIncrementType.Operation,
                Separate = "-",
                Index = 1,
                IndexFormat = "D5",
                InputValue = inputValue,
                IsActive = true
            };
            await _autoIncrementSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
