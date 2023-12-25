using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingSubOperationWFXResultRepository : GenericRepositoryAsync<SewingSubOperationWFXResult>, ISewingSubOperationWFXResultRepository
    {
        public SewingSubOperationWFXResultRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<List<SewingSubOperationWFXResult>> GetSewingSubOperationWFXResultsAsync(int sewingSubOperationWFXId)
        {
            return await _dbContext.Set<SewingSubOperationWFXResult>()
                            .Where(r => r.SewingSubOperationWFXId == sewingSubOperationWFXId)
                            .ToListAsync();
        }

        public async Task UpdateSewingSubOperationWFXResultAsync(int sewingSubOperationWFXId, List<SewingSubOperationWFXResult> entities)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingSubOperationWFXResult>().Where(s => s.SewingSubOperationWFXId == sewingSubOperationWFXId).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingSubOperationWFXResult>().AddRangeAsync(entities);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {

                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed.");
                }
            }
        }
        
    }
}
