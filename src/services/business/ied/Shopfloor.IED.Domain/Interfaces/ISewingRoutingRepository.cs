using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingRoutingRepository : IGenericRepositoryAsync<SewingRouting>
    {
        Task<SewingRouting> GetSewingRoutingByIdAsync(int id);
        Task<SewingRouting> GetSewingRoutingForExcelByIdAsync(int id);
        Task UpdateSewingRoutingAsync(SewingRouting sewingRouting, List<SewingRoutingBOL> newSewingRoutingBOLs);
        Task UpdateSewingRoutingsAsync(int sewingIEDId, List<SewingRouting> entities);
    }
}
