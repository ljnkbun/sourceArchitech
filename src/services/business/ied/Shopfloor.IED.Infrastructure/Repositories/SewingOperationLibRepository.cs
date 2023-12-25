using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingOperationLibRepository : MasterRepositoryAsync<SewingOperationLib>, ISewingOperationLibRepository
    {
        public SewingOperationLibRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingOperationLib> GetSewingOperationLibByIdAsync(int id)
        {
            return await _dbContext.Set<SewingOperationLib>()
                            .AsNoTracking()
                            .Include(s => s.SewingOperationLibBOLs)
                                .ThenInclude(b => b.SewingTaskLib)
                            .Include(s => s.SewingOperationLibBOLs)
                                .ThenInclude(b => b.SewingMacroLib)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingOperationLibAsync(SewingOperationLib entity, List<SewingOperationLibBOL> insertItems, List<SewingOperationLibBOL> deleteItems)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteItems != null && deleteItems.Count > 0)
                    {
                        _dbContext.Set<SewingOperationLibBOL>().RemoveRange(deleteItems);
                    }
                    if (insertItems != null && insertItems.Count > 0)
                    {
                        await _dbContext.Set<SewingOperationLibBOL>().AddRangeAsync(insertItems);
                    }
                    _dbContext.Set<SewingOperationLib>().Update(entity);
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
