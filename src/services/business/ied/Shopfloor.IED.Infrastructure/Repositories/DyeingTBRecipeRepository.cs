using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            .Include(x => x.DyeingTBRVersions)
            .ThenInclude(x => x.DyeingTBRCValues)
            .Include(x => x.DyeingTBRTasks)
            .ThenInclude(x => x.DyeingTBTaskChemicals)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<DyeingTBRecipe> AddDyeingTBRecipeAsync(DyeingTBRecipe entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    entity.TBRecipeNo = await GetNewRequestNoAsync();
                    if (!entity.DyeingTBRVersions.Any() && entity.VersionQty > 0)
                    {
                        for (int i = 1; i <= entity.VersionQty; i++)
                        {
                            var item = new DyeingTBRVersion
                            {
                                Version = i,
                                DoTime = DateTime.Now,
                                Approved = false,
                                IsActive = true
                            };
                            
                            entity.DyeingTBRVersions.Add(item);
                        }
                    }
                    await _dbContext.AddAsync(entity);

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            }
            return entity;
        }

        private async Task<string> GetNewRequestNoAsync()
        {
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.RC);
            string inputValue = $"{AutoIncrementType.RC}{autoIncrement.Separate}{DateTime.Now:yyyyMM}";
            if (inputValue != autoIncrement.InputValue)
            {
                autoIncrement.Index = 1;
                autoIncrement.InputValue = inputValue;
            }
            string requestNo;
            bool isUnique;
            int count = 0;
            do
            {
                requestNo = AutoIncrementHelper.GetNewRequestNo(inputValue, autoIncrement);
                isUnique = await _dbContext.Set<DyeingTBRecipe>().AllAsync(x => x.TBRecipeNo != requestNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _dbContext.Set<AutoIncrement>().Update(autoIncrement);
            return requestNo;
        }
    }
}