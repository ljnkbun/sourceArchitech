using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface ILineMachineCapacityRepository : IGenericRepositoryAsync<LineMachineCapacity>
    {
        Task<List<LineMachineCapacity>> GetLineMachineCapacityByDate(DateTime? fDate, DateTime? tDate, List<int> lineIds, List<int> machineIds);
        Task<bool> SaveLineMachineCapacitySync(List<LineMachineCapacity> entites);
    }
}
