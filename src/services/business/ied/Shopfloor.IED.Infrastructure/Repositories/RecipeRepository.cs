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
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

        public async Task<Recipe> AddRecipeAsync(Recipe entity)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    entity.RecipeNo = await GetNewRequestNoAsync();
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
            var autoIncrement = await _dbContext.Set<AutoIncrement>().FirstOrDefaultAsync(x => x.Type == AutoIncrementType.RCP);
            string inputValue = $"{AutoIncrementType.RCP}{autoIncrement.Separate}{DateTime.Now:yyyyMM}";
            if (inputValue != autoIncrement.InputValue)
            {
                autoIncrement.Index = 1;
                autoIncrement.InputValue = inputValue;
            }
            string recipeNo;
            bool isUnique;
            int count = 0;
            do
            {
                recipeNo = AutoIncrementHelper.GetNewRequestNo(inputValue, autoIncrement);
                isUnique = await _dbContext.Set<Recipe>().AllAsync(x => x.RecipeNo != recipeNo);
                autoIncrement.Index++;
                count++;
            } while (!isUnique && count < 3);
            _dbContext.Set<AutoIncrement>().Update(autoIncrement);
            return recipeNo;
        }
    }
}