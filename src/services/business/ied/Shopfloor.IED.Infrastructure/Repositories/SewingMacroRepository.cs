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
    public class SewingMacroRepository : MasterRepositoryAsync<SewingMacro>, ISewingMacroRepository
    {
        public SewingMacroRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingMacro> GetSewingMacroByIdAsync(int id)
        {
            return await _dbContext.Set<SewingMacro>()
                            .AsNoTracking()
                            .Include(s => s.SewingMacroBOLs)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateSewingMacroAsync(SewingMacro sewingMacro, List<SewingMacroBOL> newSewingMacroBOLs)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingMacroBOL>().Where(s => s.SewingMacroId == sewingMacro.Id).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingMacroBOL>().AddRangeAsync(newSewingMacroBOLs);
                    _dbContext.Set<SewingMacro>().Update(sewingMacro);
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
