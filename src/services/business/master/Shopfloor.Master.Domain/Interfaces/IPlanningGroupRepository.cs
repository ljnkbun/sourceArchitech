using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IPlanningGroupRepository : IMasterRepositoryAsync<PlanningGroup>
    {
        Task UpdatePlanningGroupFactoryAsync(PlanningGroup planningGroup, IEnumerable<PlanningGroupFactory> planningGroupFactories);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetPlanningGroupsModelAsync<TParam, TModel>(TParam parameter) where TParam : RequestParameter
    where TModel : class;

        Task<bool> IsProcessIdExits(int processId, int? id = null);
    }
}
