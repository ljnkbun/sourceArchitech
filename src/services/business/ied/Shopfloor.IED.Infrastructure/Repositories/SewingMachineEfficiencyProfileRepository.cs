using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingMachineEfficiencyProfileRepository : GenericRepositoryAsync<SewingMachineEfficiencyProfile>, ISewingMachineEfficiencyProfileRepository
    {
        public SewingMachineEfficiencyProfileRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<SewingMachineEfficiencyProfile>().AnyAsync(x => x.Id == id);
        }
        public async Task<SewingMachineEfficiencyProfile> GetByMachineAsync(int machineId)
        {
            return await _dbContext.Set<SewingMachineEfficiencyProfile>()
                                    .Include(e => e.SewingEfficiencyProfile)
                                    .FirstOrDefaultAsync(m => m.MachineId == machineId);
        }
        public async Task<bool> IsMachineUniqueAsync(int machineId, int? sewingEfficiencyProfileId = null)
        {
            return await _dbContext.Set<SewingMachineEfficiencyProfile>().AllAsync(x => x.MachineId != machineId || (x.SewingEfficiencyProfileId == sewingEfficiencyProfileId && x.MachineId == machineId));
        }
    }
}