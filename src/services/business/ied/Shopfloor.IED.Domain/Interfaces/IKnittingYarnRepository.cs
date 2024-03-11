using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IKnittingYarnRepository : IGenericRepositoryAsync<KnittingYarn>
    {
        Task UpdateKnittingYarnsAsync(int knittingIEDId, List<KnittingYarn> entities);
    }
}
