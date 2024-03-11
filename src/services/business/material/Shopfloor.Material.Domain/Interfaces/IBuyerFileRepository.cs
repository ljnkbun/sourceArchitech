using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces
{
    public interface IBuyerFileRepository : IGenericRepositoryAsync<BuyerFile>
    {
        Task<bool> IsExistAsync(int id);
    }
}