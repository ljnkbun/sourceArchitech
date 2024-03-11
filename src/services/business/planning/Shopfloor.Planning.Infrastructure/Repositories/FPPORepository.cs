using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;

namespace Shopfloor.Planning.Infrastructure.Repositories
{
    public class FPPORepository : GenericRepositoryAsync<FPPO>, IFPPORepository
    {
        public FPPORepository(PlanningContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<FPPO> GetFPPOByIdAsync(int id)
        {
            return await _dbContext.Set<FPPO>()
                            .Include(s => s.FPPODetails)
                            .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateFPPOAsync(FPPO entity, ICollection<FPPODetail> details)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<FPPODetail>().Where(s => s.FPPOId == entity.Id).ExecuteDeleteAsync();

                    if (details.Any())
                    {
                        await _dbContext.Set<FPPODetail>().AddRangeAsync(details);
                    }

                    _dbContext.Set<FPPO>().Update(entity);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex, ex.Message);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
    }
}
