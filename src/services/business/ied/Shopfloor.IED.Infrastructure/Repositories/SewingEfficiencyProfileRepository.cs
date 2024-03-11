using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingEfficiencyProfileRepository : NameRepositoryAsync<SewingEfficiencyProfile>, ISewingEfficiencyProfileRepository
    {
        public SewingEfficiencyProfileRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<SewingEfficiencyProfile>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateSewingMachineEfficiencyProfileAsync(SewingEfficiencyProfile dataSewingEfficiencyProfile, BaseUpdateEntity<SewingMachineEfficiencyProfile> dataSewingMachineEfficiencyProfile)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<SewingMachineEfficiencyProfile>().UpdateRange(dataSewingMachineEfficiencyProfile.LstDataUpdate);
                    _dbContext.Update(dataSewingEfficiencyProfile);

                    _dbContext.Set<SewingMachineEfficiencyProfile>().RemoveRange(dataSewingMachineEfficiencyProfile.LstDataDelete);

                    _dbContext.Set<SewingMachineEfficiencyProfile>().AddRange(dataSewingMachineEfficiencyProfile.LstDataAdd);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    result = false;
                    await transaction.RollbackAsync();
                }
            }
            return result;
        }

        public async Task<SewingEfficiencyProfile> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<SewingEfficiencyProfile>()
            .Include(x => x.SewingMachineEfficiencyProfiles)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<SewingEfficiencyProfile> GetDefaultSewingEfficiencyProfileAsync()
        {
            return await _dbContext.Set<SewingEfficiencyProfile>().FirstOrDefaultAsync(e => e.IsDefault == true);
        }
    }
}