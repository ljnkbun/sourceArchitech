using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IKnittingIEDRepository : IGenericRepositoryAsync<KnittingIED>
    {
        Task<KnittingIED> GetKnittingIEDByIdAsync(int id);
    }
}
