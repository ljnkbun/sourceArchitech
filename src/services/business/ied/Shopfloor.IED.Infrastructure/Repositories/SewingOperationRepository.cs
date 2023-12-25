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
    public class SewingOperationRepository : MasterRepositoryAsync<SewingOperation>, ISewingOperationRepository
    {
        public SewingOperationRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingOperation> GetSewingOperationByIdAsync(int id)
        {
            return await _dbContext.Set<SewingOperation>()
                            .AsNoTracking()
                            .Include(s => s.SewingOperationBOLs)
                                .ThenInclude(b => b.SewingTask)
                            .Include(s => s.SewingOperationBOLs)
                                .ThenInclude(b => b.SewingMacro)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingOperationAsync(SewingOperation sewingOperation, List<SewingOperationBOL> newSewingOperationBOLs)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingOperationBOL>().Where(s => s.SewingOperationId == sewingOperation.Id).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingOperationBOL>().AddRangeAsync(newSewingOperationBOLs);
                    _dbContext.Set<SewingOperation>().Update(sewingOperation);
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
