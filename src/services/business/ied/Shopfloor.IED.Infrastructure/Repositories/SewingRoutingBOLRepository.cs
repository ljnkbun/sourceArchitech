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
    public class SewingRoutingBOLRepository : GenericRepositoryAsync<SewingRoutingBOL>, ISewingRoutingBOLRepository
    {
        public SewingRoutingBOLRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        
        public async Task UpdateSewingRoutingBOLsAsync(int sewingRoutingId, List<SewingRoutingBOL> entities)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingRoutingBOL>().Where(s => s.SewingRoutingId == sewingRoutingId).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingRoutingBOL>().AddRangeAsync(entities);

                    var sewingRouting = await _dbContext.Set<SewingRouting>().FirstOrDefaultAsync(s => s.Id == sewingRoutingId);
                    sewingRouting.SMV = entities.Sum(b => b.TotalSMV);
                    _dbContext.Set<SewingRouting>().Update(sewingRouting);

                    var sewingIED = await _dbContext.Set<SewingIED>().FirstOrDefaultAsync(s => s.Id == sewingRouting.SewingIEDId);
                    sewingIED.SMV = _dbContext.Set<SewingRouting>().AsNoTracking().Where(r => r.SewingIEDId == sewingIED.Id && r.Id != sewingRoutingId).Sum(b => b.SMV) + sewingRouting.SMV;
                    _dbContext.Set<SewingIED>().Update(sewingIED);

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    Log.Error(ex.Message, ex);
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
    }
}
