using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingYarnRepository : IGenericRepositoryAsync<WeavingYarn>
    {
        Task<List<WeavingYarn>> GetAllByWeavingIEDId(int weavingId);
    }
}