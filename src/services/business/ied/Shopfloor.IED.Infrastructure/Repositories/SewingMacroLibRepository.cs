using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingMacroLibRepository : MasterRepositoryAsync<SewingMacroLib>, ISewingMacroLibRepository
    {
        public SewingMacroLibRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingMacroLib> GetSewingMacroLibByIdAsync(int id)
        {
            return await _dbContext.Set<SewingMacroLib>()
                            .AsNoTracking()
                            .Include(s => s.SewingMacroLibBOLs)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingMacroLibAsync(SewingMacroLib entity, List<SewingMacroLibBOL> insertItems, List<SewingMacroLibBOL> deleteItems)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    if (deleteItems != null && deleteItems.Count > 0)
                    {
                        _dbContext.Set<SewingMacroLibBOL>().RemoveRange(deleteItems);
                    }
                    if (insertItems != null && insertItems.Count > 0)
                    {
                        await _dbContext.Set<SewingMacroLibBOL>().AddRangeAsync(insertItems);
                    }
                    _dbContext.Set<SewingMacroLib>().Update(entity);
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
