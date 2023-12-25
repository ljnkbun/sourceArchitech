using AutoMapper;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingFeatureRepository : MasterRepositoryAsync<SewingFeature>, ISewingFeatureRepository
    {
        public SewingFeatureRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingFeature> GetSewingFeatureByIdAsync(int id)
        {
            return await _dbContext.Set<SewingFeature>()
                            .AsNoTracking()
                            .Include(s => s.SewingFeatureBOLs)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingFeatureAsync(SewingFeature sewingFeature, List<SewingFeatureBOL> newSewingFeatureBOLs)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingFeatureBOL>().Where(s => s.SewingFeatureId == sewingFeature.Id).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingFeatureBOL>().AddRangeAsync(newSewingFeatureBOLs);
                    _dbContext.Set<SewingFeature>().Update(sewingFeature);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Updating failed.");
                }
            }
        }

    }
}
