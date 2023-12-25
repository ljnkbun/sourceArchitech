using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingFeatureLibRepository : MasterRepositoryAsync<SewingFeatureLib>, ISewingFeatureLibRepository
    {
        public SewingFeatureLibRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingFeatureLib> GetSewingFeatureLibByIdAsync(int id)
        {
            return await _dbContext.Set<SewingFeatureLib>()
                            .AsNoTracking()
                            .Include(s => s.SewingFeatureLibBOLs)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingFeatureLibAsync(SewingFeatureLib entity, List<SewingFeatureLibBOL> insertItems, List<SewingFeatureLibBOL> deleteItems)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteItems != null && deleteItems.Count > 0)
                    {
                        _dbContext.Set<SewingFeatureLibBOL>().RemoveRange(deleteItems);
                    }
                    if (insertItems != null && insertItems.Count > 0)
                    {
                        await _dbContext.Set<SewingFeatureLibBOL>().AddRangeAsync(insertItems);
                    }
                    _dbContext.Set<SewingFeatureLib>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed.");
                }
            }
        }

    }
}
