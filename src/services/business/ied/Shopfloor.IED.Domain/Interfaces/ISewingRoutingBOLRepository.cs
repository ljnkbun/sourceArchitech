using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingRoutingBOLRepository : IGenericRepositoryAsync<SewingRoutingBOL>
    {
        Task UpdateSewingRoutingBOLsAsync(int sewingRoutingId, List<SewingRoutingBOL> entities);
    }
}
