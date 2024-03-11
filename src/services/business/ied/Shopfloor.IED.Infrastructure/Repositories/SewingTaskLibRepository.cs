using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingTaskLibRepository : MasterRepositoryAsync<SewingTaskLib>, ISewingTaskLibRepository
    {
        public SewingTaskLibRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingTaskLib> GetSewingTaskLibByIdAsync(int id)
        {
            return await _dbContext.Set<SewingTaskLib>()
                                    .Include(w => w.SewingMachineEfficiencyProfile)
                                        .ThenInclude(w => w.SewingEfficiencyProfile)
                                    .Include(w => w.SewingBundle)
                                    .FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task<SewingTaskLib> GetBySewingBundleIdAsync(int id)
        {
            return await _dbContext.Set<SewingTaskLib>().FirstOrDefaultAsync(t => t.SewingBundleId == id);
        }
        public async Task<List<SewingTaskLib>> GetByIdsAsync(ICollection<int> ids)
        {
            return await _dbContext.Set<SewingTaskLib>()
                                    .Include(t => t.SewingMachineEfficiencyProfile.SewingEfficiencyProfile)
                                    .Where(w => ids.Contains(w.Id)).ToListAsync();
        }
    }
}
