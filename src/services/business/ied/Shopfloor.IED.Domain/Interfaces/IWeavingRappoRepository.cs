using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingRappoRepository : IGenericRepositoryAsync<WeavingRappo>
    {
        Task<WeavingRappo> GetWeavingRappoByIdAsync(int id);

        Task UpdateWeavingRappoAsync(WeavingRappo entity, List<WeavingRappoMark> deleteMarks, List<WeavingRappoMatric> deleteMatrics, List<WeavingRappoMark> insertMarks, List<WeavingRappoMatric> insertMatrics);

        Task<bool> IsExistByWeavingIEDId(int weavingId);

        Task<WeavingRappo> GetByWeavingIEDId(int weavingId);
    }
}