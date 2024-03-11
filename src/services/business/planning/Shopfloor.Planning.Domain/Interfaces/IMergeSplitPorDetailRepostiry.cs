using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IMergeSplitPorDetailRepostiry : IGenericRepositoryAsync<MergeSplitPorDetail>
    {
        Task<List<MergeSplitPorDetail>> GetByToPorDetailIds(ICollection<int> ids);
    }
}
