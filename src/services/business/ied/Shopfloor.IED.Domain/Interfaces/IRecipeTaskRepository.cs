using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IRecipeTaskRepository : IGenericRepositoryAsync<RecipeTask>
{
    Task<bool> IsExistAsync(int id);

    Task<RecipeTask> GetWithIncludeByIdAsync(int id);

    Task<PagedResponse<IReadOnlyList<TModel>>> GetRecipeTaskPagedResponseAsync<TParam, TModel>(TParam parameter)
        where TParam : RequestParameter where TModel : class;
}