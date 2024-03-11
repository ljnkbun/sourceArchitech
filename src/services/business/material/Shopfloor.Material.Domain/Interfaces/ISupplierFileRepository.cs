using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces
{
    public interface ISupplierFileRepository : IGenericRepositoryAsync<SupplierFile>
    {
        Task<bool> IsExistAsync(int id);
    }
}