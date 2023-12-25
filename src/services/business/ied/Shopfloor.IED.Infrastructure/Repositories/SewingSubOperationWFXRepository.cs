using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class SewingSubOperationWFXRepository : GenericRepositoryAsync<SewingSubOperationWFX>, ISewingSubOperationWFXRepository
    {
        public SewingSubOperationWFXRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingSubOperationWFX> GetSewingSubOperationWFXByIdAsync(int id)
        {
            return await _dbContext.Set<SewingSubOperationWFX>()
                                    .Include(w => w.SewingSubOperationWFXBOLs)
                                    .FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task UpdateSewingSubOperationWFXAsync(SewingSubOperationWFX sewingSubOperationWFX, List<SewingSubOperationWFXBOL> newSewingSubOperationWFXBOLs)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingSubOperationWFXBOL>().Where(s => s.SewingSubOperationWFXId == sewingSubOperationWFX.Id).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingSubOperationWFXBOL>().AddRangeAsync(newSewingSubOperationWFXBOLs);
                    _dbContext.Set<SewingSubOperationWFX>().Update(sewingSubOperationWFX);
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
