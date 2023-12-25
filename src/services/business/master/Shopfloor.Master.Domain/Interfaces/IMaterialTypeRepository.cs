using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IMaterialTypeRepository : IMasterRepositoryAsync<MaterialType>
    {
        Task<MaterialType> GetMaterialTypeByIdAsync(int id);
        Task UpdateMaterialTypeAsync(MaterialType entity, IEnumerable<CategoryMapMaterialType> categoryMapMaterialTypes);
    }
}
