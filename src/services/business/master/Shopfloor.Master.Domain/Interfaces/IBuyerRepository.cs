using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IBuyerRepository : IGenericRepositoryAsync<Buyer>
    {
        Task<bool> IsUniqueAsync(string code, int? id = null);
    }
}