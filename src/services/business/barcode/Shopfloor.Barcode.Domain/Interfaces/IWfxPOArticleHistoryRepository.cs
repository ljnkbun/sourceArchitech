using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IWfxPOArticleHistoryRepository : IGenericRepositoryAsync<WfxPOArticleHistory>
    {
        Task<ICollection<WfxPOArticleHistory>> GetByWfxPOIdAsync(int[] wfxPOIds);
    }
}
