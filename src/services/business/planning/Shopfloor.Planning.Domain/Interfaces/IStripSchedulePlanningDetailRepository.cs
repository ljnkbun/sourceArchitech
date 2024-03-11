using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IStripSchedulePlanningDetailRepository : IGenericRepositoryAsync<StripSchedulePlanningDetail>
    {
        Task<StripSchedulePlanningDetail> GetByFPPOIdAsync(int id, DateTime date);
    }
}
