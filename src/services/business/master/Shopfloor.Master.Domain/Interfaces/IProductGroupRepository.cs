using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IProductGroupRepository : IMasterRepositoryAsync<ProductGroup>
    {
        Task<ProductGroup> GetProductGroupByIdAsync(int id);
        Task UpdateProductGroupAsync(ProductGroup entity, BaseUpdateEntity<MaterialTypeMapProductGroup> materialTypeMapProductGroups);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetProductGroupPagedResponseAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter where TModel : class;

        Task<bool> IsExistAsync(int id);
    }
}
