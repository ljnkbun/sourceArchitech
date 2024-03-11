using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IPlanningGroupFactoryRepository : IGenericRepositoryAsync<PlanningGroupFactory>
    {
        Task<IReadOnlyList<PlanningGroupFactory>> GetByIds(List<int> ids);
    }
}
