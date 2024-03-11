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
    public class SewingRoutingRepository : GenericRepositoryAsync<SewingRouting>, ISewingRoutingRepository
    {
        public SewingRoutingRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<SewingRouting> GetSewingRoutingByIdAsync(int id)
        {
            return await _dbContext.Set<SewingRouting>()
                                    .Include(w => w.SewingRoutingBOLs.OrderBy(r => r.LineNumber))
                                        .ThenInclude(b => b.SewingOperationLib)
                                    .Include(w => w.SewingRoutingBOLs.OrderBy(r => r.LineNumber))
                                        .ThenInclude(b => b.SewingFeatureLib)
                                    .FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task<SewingRouting> GetSewingRoutingForExcelByIdAsync(int id)
        {
            return await _dbContext.Set<SewingRouting>()
                                    .Include(r => r.SewingRoutingBOLs.OrderBy(r => r.LineNumber))
                                        .ThenInclude(b => b.SewingOperationLib.SewingOperationLibBOLs)
                                            .ThenInclude(o => o.SewingTaskLib.SewingMachineEfficiencyProfile)
                                    .Include(w => w.SewingRoutingBOLs.OrderBy(r => r.LineNumber))
                                        .ThenInclude(b => b.SewingFeatureLib.SewingFeatureLibBOLs)
                                            .ThenInclude(b => b.SewingOperationLib.SewingOperationLibBOLs)
                                                .ThenInclude(o => o.SewingTaskLib.SewingMachineEfficiencyProfile)
                                    .Include(r => r.SewingIED)
                                        .ThenInclude(s => s.RequestArticleOutput.RequestDivisionProcess.RequestDivision.Request)
                                    .FirstOrDefaultAsync(w => w.Id == id);
        }
        public async Task UpdateSewingRoutingAsync(SewingRouting sewingRouting, List<SewingRoutingBOL> newSewingRoutingBOLs)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<SewingRoutingBOL>().Where(s => s.SewingRoutingId == sewingRouting.Id).ExecuteDeleteAsync();
                    await _dbContext.Set<SewingRoutingBOL>().AddRangeAsync(newSewingRoutingBOLs);
                    _dbContext.Set<SewingRouting>().Update(sewingRouting);

                    var sewingIED = await _dbContext.Set<SewingIED>().FirstOrDefaultAsync(s => s.Id == sewingRouting.SewingIEDId);
                    sewingIED.SMV = _dbContext.Set<SewingRouting>().AsNoTracking().Where(r => r.SewingIEDId == sewingIED.Id && r.Id != sewingRouting.Id).Sum(b => b.SMV) + sewingRouting.SMV;
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
        public async Task UpdateSewingRoutingsAsync(int sewingIEDId, List<SewingRouting> entities)
        {
            var newRoutingIds = entities.Select(l => l.Id);
            var currentRoutings = _dbContext.Set<SewingRouting>().Where(s => s.SewingIEDId == sewingIEDId);
            var currentRoutingIds = await currentRoutings.Select(r => r.Id).ToListAsync();
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await currentRoutings.Where(s => !newRoutingIds.Contains(s.Id)).ExecuteDeleteAsync();

                    var newEntities = entities.Where(e => e.Id == 0);
                    await _dbContext.Set<SewingRouting>().AddRangeAsync(newEntities);

                    var updateEntities = entities.Where(e => currentRoutingIds.Contains(e.Id));
                    _dbContext.Set<SewingRouting>().UpdateRange(updateEntities);

                    var sewingIED = await _dbContext.Set<SewingIED>().FirstOrDefaultAsync(s => s.Id == sewingIEDId);
                    sewingIED.SMV = entities.Sum(b => b.SMV);
                    _dbContext.Set<SewingIED>().Update(sewingIED);

                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, ex.Message);
                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
    }
}
