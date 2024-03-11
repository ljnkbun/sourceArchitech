using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingTBRecipeRepository : GenericRepositoryAsync<DyeingTBRecipe>, IDyeingTBRecipeRepository
    {
        public DyeingTBRecipeRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingTBRecipe>().AnyAsync(x => x.Id == id);
        }

        public async Task<DyeingTBRecipe> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRecipe>()
            .Include(x => x.DyeingTBRTasks)
            .ThenInclude(x => x.DyeingTBRChemicals)
            .ThenInclude(x => x.DyeingTBRChemicalValues)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<DyeingTBRecipe> GetWithIncludeByColorIdAsync(int dyeingTbMaterialColorId) => await _dbContext.Set<DyeingTBRecipe>()
            .Include(x => x.DyeingTBRTasks)
            .ThenInclude(x => x.DyeingTBRChemicals)
            .ThenInclude(x => x.DyeingTBRChemicalValues)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DyeingTBMaterialColorId == dyeingTbMaterialColorId);

        public async Task<DyeingTBRecipe> GetParentWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingTBRecipe>()
            .Include(x => x.DyeingTBRTasks)
            .ThenInclude(x => x.DyeingTBRChemicals)
            .ThenInclude(x => x.DyeingTBRChemicalValues)
            .Include(x => x.DyeingTBMaterialColor)
            .ThenInclude(x => x.DyeingTBMaterial)
            .ThenInclude(x => x.DyeingTBRequest)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<DyeingTBRecipe> AddDyeingTBRecipeAsync(DyeingTBRecipe entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var parentRequestNo = _dbContext.Set<DyeingTBMaterialColor>()
                        .Include(x => x.DyeingTBMaterial)
                        .ThenInclude(x => x.DyeingTBRequest).AsNoTracking().FirstOrDefault(x => x.Id == entity.DyeingTBMaterialColorId)?.DyeingTBMaterial?.DyeingTBRequest?.RequestNo;
                    entity.TBRecipeNo = await GetNewRequestNoAsync(parentRequestNo);
                    await _dbContext.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch(Exception ex) 
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex, ex.Message);
                    throw new ApiException($"Creating failed. {ex.InnerException?.Message}");
                }
            }
            return entity;
        }

        public async Task<bool> UpdateDyeingTBRecipeAsync(DyeingTBRecipe dataDyeingTBRecipeUpdate, BaseUpdateEntity<DyeingTBRTask> dataDyeingTBRTask, BaseUpdateEntity<DyeingTBRChemical> dataDyeingTBRChemical, BaseUpdateEntity<DyeingTBRChemicalValue> dataDyeingTBRChemicalValue)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<DyeingTBRChemicalValue>().RemoveRange(dataDyeingTBRChemicalValue.LstDataDelete);
                    _dbContext.Set<DyeingTBRChemical>().RemoveRange(dataDyeingTBRChemical.LstDataDelete);
                    _dbContext.Set<DyeingTBRTask>().RemoveRange(dataDyeingTBRTask.LstDataDelete);

                    _dbContext.Set<DyeingTBRTask>().AddRange(dataDyeingTBRTask.LstDataAdd);
                    _dbContext.Set<DyeingTBRChemical>().AddRange(dataDyeingTBRChemical.LstDataAdd);
                    _dbContext.Set<DyeingTBRChemicalValue>().AddRange(dataDyeingTBRChemicalValue.LstDataAdd);

                    _dbContext.Update(dataDyeingTBRecipeUpdate);
                    _dbContext.Set<DyeingTBRTask>().UpdateRange(dataDyeingTBRTask.LstDataUpdate);
                    _dbContext.Set<DyeingTBRChemical>().UpdateRange(dataDyeingTBRChemical.LstDataUpdate);
                    _dbContext.Set<DyeingTBRChemicalValue>().UpdateRange(dataDyeingTBRChemicalValue.LstDataUpdate);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    result = false;
                    await transaction.RollbackAsync();
                    Log.Error(ex, ex.Message);
                    throw new ApiException($"updating failed. {ex.InnerException?.Message}");
                }
            }
            return result;
        }

        private async Task<string> GetNewRequestNoAsync(string inputValue)
        {
            string requestNo;
            bool isUnique;
            int count = 0;
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.RCRP && x.InputValue == inputValue) ?? new AutoIncrement
            {
                Type = AutoIncrementType.RCRP,
                Separate = "-",
                Index = 1,
                IndexFormat = "D2",
                IsActive = true,
                InputValue = inputValue
            };
            do
            {
                requestNo = AutoIncrementHelper.GetNewCode(inputValue, autoIncrement);
                isUnique = await _dbContext.Set<DyeingTBRecipe>().AllAsync(x => x.TBRecipeNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            if (autoIncrement.Id == 0)
            {
                _dbContext.Set<AutoIncrement>().Add(autoIncrement);
            }
            else
            {
                _dbContext.Set<AutoIncrement>().Update(autoIncrement);
            }
            return requestNo;
        }
    }
}