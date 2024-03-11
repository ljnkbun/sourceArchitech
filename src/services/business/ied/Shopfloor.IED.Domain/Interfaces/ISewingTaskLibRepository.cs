using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingTaskLibRepository : IMasterRepositoryAsync<SewingTaskLib>
    {
        Task<SewingTaskLib> GetSewingTaskLibByIdAsync(int id);
        Task<SewingTaskLib> GetBySewingBundleIdAsync(int id);
        Task<List<SewingTaskLib>> GetByIdsAsync(ICollection<int> ids);
    }
}
