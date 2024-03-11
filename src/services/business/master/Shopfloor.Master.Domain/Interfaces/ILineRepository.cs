using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface ILineRepository : IMasterRepositoryAsync<Line>
    {
        Task<IReadOnlyList<Line>> GetLineByIdsAsync(List<int> ids);
    }
}
