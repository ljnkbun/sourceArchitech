using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IDyeingTBRTaskRepository : IGenericRepositoryAsync<DyeingTBRTask>
    {
        Task<bool> IsExistAsync(int id);

        Task<bool> IsUniqueAsync(string code, int? id = null);

        Task<DyeingTBRTask> GetWithIncludeByIdAsync(int id);

        Task<PagedResponse<IReadOnlyList<TModel>>> GetTaskPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class;
    }
}