using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Application.Helpers;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class RecipeRepository : GenericRepositoryAsync<Recipe>, IRecipeRepository
    {
        public RecipeRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<Recipe>().AnyAsync(x => x.Id == id && !x.Deleted);
        }

        public async Task<bool> IsExistByRecipeIdAsync(int recipeId)
        {
            return await _dbContext.Set<Recipe>().AnyAsync(x => x.DyeingTBRecipeId == recipeId && !x.Deleted);
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetRecipePagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<Recipe>().Where(x => !x.Deleted).Filter(parameter);
            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                .OrderBy(parameter.OrderBy)
                .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                .Paged(parameter.PageSize, parameter.PageNumber)
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return response;
        }

        public async Task<Recipe> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<Recipe>()
            .Include(x => x.RecipeTasks)
            .ThenInclude(x => x.RecipeChemicals)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);
        public async Task<Recipe> GetWithIncludeByDyeingTBRecipeIdAsync(int dyeingTBRecipeId) => await _dbContext.Set<Recipe>()
            .Include(x => x.RecipeTasks)
            .ThenInclude(x => x.RecipeChemicals)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DyeingTBRecipeId == dyeingTBRecipeId && !x.Deleted);

        public async Task<Recipe> AddRecipeAsync(Recipe entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    entity.RecipeNo = _dbContext.Set<DyeingTBRecipe>().FirstOrDefault(x => x.Id == entity.DyeingTBRecipeId)?.TBRecipeNo;
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
        public async Task<Recipe> GetByTBRecipeIdAsync(int id)
        {
            return await _dbContext.Set<Recipe>().FirstOrDefaultAsync(r => r.DyeingTBRecipeId == id);
        }
    }
}