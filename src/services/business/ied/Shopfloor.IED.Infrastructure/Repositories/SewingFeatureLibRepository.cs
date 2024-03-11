using AutoMapper;
using MassTransit.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingFeatureLibRepository : MasterRepositoryAsync<SewingFeatureLib>, ISewingFeatureLibRepository
    {
        private readonly DbSet<SewingFeatureLib> _dbSet;
        private readonly DbSet<AutoIncrement> _autoIncrementSet;
        public SewingFeatureLibRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _dbSet = _dbContext.Set<SewingFeatureLib>();
            _autoIncrementSet = _dbContext.Set<AutoIncrement>();
        }
        public async Task<SewingFeatureLib> GetSewingFeatureLibByIdAsync(int id)
        {
            return await _dbContext.Set<SewingFeatureLib>()
                            .AsNoTracking()
                            .Include(s => s.SewingFeatureLibBOLs.OrderBy(r => r.LineNumber))
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingFeatureLibAsync(SewingFeatureLib entity, List<SewingFeatureLibBOL> insertItems, List<SewingFeatureLibBOL> deleteItems)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteItems != null && deleteItems.Count > 0)
                    {
                        _dbContext.Set<SewingFeatureLibBOL>().RemoveRange(deleteItems);
                    }
                    if (insertItems != null && insertItems.Count > 0)
                    {
                        await _dbContext.Set<SewingFeatureLibBOL>().AddRangeAsync(insertItems);
                    }
                    _dbContext.Set<SewingFeatureLib>().Update(entity);
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

        public async Task<SewingFeatureLib> AddSewingFeatureLibAsync(SewingFeatureLib entity)
        {
            var componentCode = await _dbContext.Set<SewingComponent>().FirstOrDefaultAsync(c => c.Id == entity.SewingComponentId).Select(c => c.Code);
            if (componentCode == null)
                throw new ApiException($"SewingComponent with Id {entity.SewingComponentId} not found.");
            entity.Code = await GenerateCodeAsync(entity.BuyerCode, entity.SubCategoryCode, componentCode);
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private async Task<string> GenerateCodeAsync(string buyerCode, string subCategoryCode, string componentCode)
        {
            var operationAutoIncrement = await _autoIncrementSet.AsNoTracking().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Feature);
            if (operationAutoIncrement == null)
                throw new ApiException("AutoIncrement with type Feature is not found.");

            string inputValue = $"{buyerCode}{operationAutoIncrement.Separate}{subCategoryCode}{operationAutoIncrement.Separate}{componentCode}";
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
            var autoIncrement = await _autoIncrementSet.FirstOrDefaultAsync(x => x.Type == AutoIncrementType.Feature && x.InputValue == inputValue);
            if (autoIncrement != null)
                return autoIncrement;
            
            var entity = new AutoIncrement()
            {
                Type = AutoIncrementType.Feature,
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
