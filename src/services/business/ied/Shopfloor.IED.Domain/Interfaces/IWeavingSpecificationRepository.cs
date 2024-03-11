using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingSpecificationRepository : IGenericRepositoryAsync<WeavingYarn>
    {
        Task AddWeavingSpecificationAsync(BaseUpdateEntity<WeavingYarn> weavingYarns, BaseUpdateEntity<WeavingDetailStructure> weavingDetailStructures, WeavingRusticFabricSpec weavingRusticFabricSpec);

        Task AddWeavingRappoSpecificationAsync(BaseUpdateEntity<WeavingYarn> weavingYarns,
            BaseUpdateEntity<WeavingDetailStructure> weavingDetailStructures, WeavingRusticFabricSpec weavingRusticFabricSpec, WeavingRappo weavingRappo,
            BaseUpdateEntity<WeavingRappoMark> weavingRappoMarks,
            BaseUpdateEntity<WeavingRappoMatric> weavingRappoMatrics);
    }
}