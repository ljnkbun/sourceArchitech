using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface ICategoryMapMaterialTypeRepository : IGenericRepositoryAsync<CategoryMapMaterialType>
    {
        Task<bool> IsDuplicateAsync(int? materialTypeId, int? categoryId, int? id = null);
    }
}
