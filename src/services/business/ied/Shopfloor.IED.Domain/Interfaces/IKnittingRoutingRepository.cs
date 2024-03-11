using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IKnittingRoutingRepository : IGenericRepositoryAsync<KnittingRouting>
    {
        Task UpdateKnittingRoutingsAsync(int knittingIEDId, List<KnittingRouting> entities);
    }
}
