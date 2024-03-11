using AutoMapper;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingMacroLibRepository : MasterRepositoryAsync<SewingMacroLib>, ISewingMacroLibRepository
    {
        private readonly DbSet<SewingMacroLib> _dbSet;
        private readonly DbSet<AutoIncrement> _autoIncrementSet;
        public SewingMacroLibRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbSet = _dbContext.Set<SewingMacroLib>();
            _autoIncrementSet = _dbContext.Set<AutoIncrement>();
        }
        public async Task<SewingMacroLib> GetSewingMacroLibByIdAsync(int id)
        {
            return await _dbContext.Set<SewingMacroLib>()
                            .AsNoTracking()
                            .Include(s => s.SewingMacroLibBOLs.OrderBy(r => r.LineNumber))
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingMacroLibAsync(SewingMacroLib entity, List<SewingMacroLibBOL> insertItems, List<SewingMacroLibBOL> deleteItems)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteItems != null && deleteItems.Count > 0)
                    {
                        _dbContext.Set<SewingMacroLibBOL>().RemoveRange(deleteItems);
                    }
                    if (insertItems != null && insertItems.Count > 0)
                    {
                        await _dbContext.Set<SewingMacroLibBOL>().AddRangeAsync(insertItems);
                    }
                    _dbContext.Set<SewingMacroLib>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }

        public async Task<SewingMacroLib> AddSewingMacroLibAsync(SewingMacroLib entity)
        {
            var componentCode = await _dbContext.Set<SewingComponentGroup>().FirstOrDefaultAsync(c => c.Id == entity.SewingComponentGroupId).Select(c => c.Code);
            if (componentCode == null)
                throw new ApiException($"SewingComponent with Id {entity.SewingComponentGroupId} not found.");
            entity.Code = await GenerateCodeAsync(componentCode);
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private async Task<string> GenerateCodeAsync(string componentCode)
        {
            var operationAutoIncrement = await _autoIncrementSet.AnyAsync(x => x.Type == AutoIncrementType.Macro);
            if (operationAutoIncrement == false)
                throw new ApiException("AutoIncrement with type Macro is not found.");

            string inputValue = $"{componentCode}";
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
            var autoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Macro && x.InputValue == inputValue);
            if (autoIncrement != null) 
                return autoIncrement;

            var entity = new AutoIncrement()
            {
                Type = AutoIncrementType.Macro,
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
