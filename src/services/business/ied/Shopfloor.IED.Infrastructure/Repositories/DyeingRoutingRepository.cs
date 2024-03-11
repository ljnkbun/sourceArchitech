using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class DyeingRoutingRepository : GenericRepositoryAsync<DyeingRouting>, IDyeingRoutingRepository
    {
        public DyeingRoutingRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<DyeingRouting>().AnyAsync(x => x.Id == id);
        }

        public async Task<DyeingRouting> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<DyeingRouting>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateDyeingRoutingsAsync(int dyeingIEDId, List<DyeingRouting> entities)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<DyeingRouting>().Where(s => s.DyeingIEDId == dyeingIEDId).ExecuteDeleteAsync();
                    await _dbContext.Set<DyeingRouting>().AddRangeAsync(entities);
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