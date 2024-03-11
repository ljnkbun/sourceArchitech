using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces
{
    public interface IMaterialRequestFileRepository : IGenericRepositoryAsync<MaterialRequestFile>
    {
        Task<bool> IsExistAsync(int id);
    }
}