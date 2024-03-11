using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingRappoRepository : GenericRepositoryAsync<WeavingRappo>, IWeavingRappoRepository
    {
        public WeavingRappoRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<WeavingRappo> GetWeavingRappoByIdAsync(int id)
        {
            return await _dbContext.Set<WeavingRappo>()
                                    .Include(r => r.WeavingRappoMarks)
                                    .Include(r => r.WeavingRappoMatrics)
                                    .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateWeavingRappoAsync(WeavingRappo entity, List<WeavingRappoMark> deleteMarks, List<WeavingRappoMatric> deleteMatrics, List<WeavingRappoMark> insertMarks, List<WeavingRappoMatric> insertMatrics)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteMarks != null && deleteMarks.Any())
                    {
                        _dbContext.Set<WeavingRappoMark>().RemoveRange(deleteMarks);
                    }
                    if (deleteMatrics != null && deleteMatrics.Any())
                    {
                        _dbContext.Set<WeavingRappoMatric>().RemoveRange(deleteMatrics);
                    }
                    if (insertMarks != null && insertMarks.Any())
                    {
                        await _dbContext.Set<WeavingRappoMark>().AddRangeAsync(insertMarks);
                    }
                    if (insertMatrics != null && insertMatrics.Any())
                    {
                        await _dbContext.Set<WeavingRappoMatric>().AddRangeAsync(insertMatrics);
                    }
                    _dbContext.Set<WeavingRappo>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }

        public async Task<bool> IsExistByWeavingIEDId(int weavingId) => await _dbContext.Set<WeavingRappo>().AsNoTracking()
            .AnyAsync(x => x.WeavingIEDId == weavingId);

        public async Task<WeavingRappo> GetByWeavingIEDId(int weavingId) => await _dbContext.Set<WeavingRappo>().Include(x => x.WeavingRappoMarks)
            .Include(x => x.WeavingRappoMatrics)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.WeavingIEDId == weavingId);
    }
}