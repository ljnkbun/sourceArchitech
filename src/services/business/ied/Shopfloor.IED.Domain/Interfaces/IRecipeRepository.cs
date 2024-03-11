using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IRecipeRepository : IGenericRepositoryAsync<Recipe>
{
    Task<bool> IsExistAsync(int id);

    Task<Recipe> GetWithIncludeByIdAsync(int id);

    Task<Recipe> AddRecipeAsync(Recipe entity);

    Task<bool> IsExistByRecipeIdAsync(int recipeId);

    Task<PagedResponse<IReadOnlyList<TModel>>> GetRecipePagedResponseAsync<TParam, TModel>(TParam parameter)
        where TParam : RequestParameter where TModel : class;

    Task<Recipe> GetByTBRecipeIdAsync(int id);

    Task<Recipe> GetWithIncludeByDyeingTBRecipeIdAsync(int dyeingTBRecipeId);
}