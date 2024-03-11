using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IMachineRepository : IMasterRepositoryAsync<Machine>
    {
        Task<ICollection<Machine>> GetMachineByIdsAsync(List<int> ids);
    }
}
