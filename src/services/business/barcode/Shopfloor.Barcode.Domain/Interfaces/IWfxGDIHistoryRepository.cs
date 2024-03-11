using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IWfxGDIHistoryRepository : IGenericRepositoryAsync<WfxGDIHistory>
    {
        Task<ICollection<WfxGDIHistory>> GetByWfxGDIIdAsync(int[] wfxGDIIds);
    }

}
