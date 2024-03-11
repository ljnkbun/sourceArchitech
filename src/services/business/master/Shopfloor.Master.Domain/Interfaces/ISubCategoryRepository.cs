using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface ISubCategoryRepository : IMasterRepositoryAsync<SubCategory>
    {
        Task<bool> IsExistAsync(int id);

        Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedAsync<TParam, TModel>(TParam parameter,
            string productGroupName) where TParam : RequestParameter where TModel : class;
    }
}
