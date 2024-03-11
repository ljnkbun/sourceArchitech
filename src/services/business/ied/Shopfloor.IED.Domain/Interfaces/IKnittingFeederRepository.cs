using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IKnittingFeederRepository : IGenericRepositoryAsync<KnittingFeeder>
    {
        Task<bool> IsUniqueAsync(string name, int? id = null);
    }
}
