using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces;

public interface IMaterialRequestDynamicColumnRepository : IGenericRepositoryAsync<MaterialRequestDynamicColumn>
{
    Task<bool> IsUniqueAsync(int dynamicColumnId, int? id = null);

    Task<bool> IsExistAsync(int dynamicColumnId);
}