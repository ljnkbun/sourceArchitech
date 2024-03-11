using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface ISewingMachineEfficiencyProfileRepository : IGenericRepositoryAsync<SewingMachineEfficiencyProfile>
{
    Task<bool> IsExistAsync(int id);
    Task<SewingMachineEfficiencyProfile> GetByMachineAsync(int machineId);
    Task<bool> IsMachineUniqueAsync(int machineId, int? sewingEfficiencyProfileId = null);
}