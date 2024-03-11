using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IQCDefectRepository : IMasterRepositoryAsync<QCDefect>
    {
        Task<ICollection<QCDefect>> GetByIdsAsync(int[] ids);
    }
}
