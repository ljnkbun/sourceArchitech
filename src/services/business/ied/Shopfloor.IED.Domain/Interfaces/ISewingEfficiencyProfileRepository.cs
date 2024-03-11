using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface ISewingEfficiencyProfileRepository : INameRepositoryAsync<SewingEfficiencyProfile>
{
    Task<bool> IsExistAsync(int id);

    Task<SewingEfficiencyProfile> GetWithIncludeByIdAsync(int id);

    Task<bool> UpdateSewingMachineEfficiencyProfileAsync(SewingEfficiencyProfile dataSewingEfficiencyProfile,
        BaseUpdateEntity<SewingMachineEfficiencyProfile> dataSewingMachineEfficiencyProfile);

    Task<SewingEfficiencyProfile> GetDefaultSewingEfficiencyProfileAsync();
}