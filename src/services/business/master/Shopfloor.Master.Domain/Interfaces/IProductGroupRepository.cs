using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IProductGroupRepository : IMasterRepositoryAsync<ProductGroup>
    {
        Task<ProductGroup> GetProductGroupByIdAsync(int id);
        Task UpdateProductGroupAsync(ProductGroup entity, IEnumerable<MaterialTypeMapProductGroup> MaterialTypeMapProductGroups);
    }
}
