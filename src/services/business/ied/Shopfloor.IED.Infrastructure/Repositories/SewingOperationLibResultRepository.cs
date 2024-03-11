using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingOperationLibResultRepository : GenericRepositoryAsync<SewingOperationLibResult>, ISewingOperationLibResultRepository
    {
        public SewingOperationLibResultRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<SewingOperationLibResult>> GetSewingOperationLibResultsAsync(int SewingOperationLibId)
        {
            return await _dbContext.Set<SewingOperationLibResult>()
                            .Where(r => r.SewingOperationLibId == SewingOperationLibId)
                            .ToListAsync();
        }

        public async Task UpdateSewingOperationLibResultAsync(int SewingOperationLibId, List<SewingOperationLibResult> entities)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingOperationLibResult>().Where(s => s.SewingOperationLibId == SewingOperationLibId).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingOperationLibResult>().AddRangeAsync(entities);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {

                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
    }
}
