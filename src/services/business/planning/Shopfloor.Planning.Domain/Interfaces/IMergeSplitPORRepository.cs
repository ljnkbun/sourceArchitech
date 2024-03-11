using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IMergeSplitPORRepository : IGenericRepositoryAsync<MergeSplitPOR>
    {
        Task<List<MergeSplitPOR>> GetByToPorIds(ICollection<int> ids);
        Task DeleteMergeSplitPorAsync(ICollection<POR> porUpdates, ICollection<PORDetail> pORDetailUpdates, ICollection<MergeSplitPorDetail> mergeSplitPorDetails, POR por);
    }
}
