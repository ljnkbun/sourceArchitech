using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingDetailStructureRepository : IGenericRepositoryAsync<WeavingDetailStructure>
    {
        Task<List<WeavingDetailStructure>> GetAllByWeavingIEDId(int weavingId);
    }
}