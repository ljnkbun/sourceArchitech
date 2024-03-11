using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class KnittingYarnRepository : GenericRepositoryAsync<KnittingYarn>, IKnittingYarnRepository
    {
        public KnittingYarnRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task UpdateKnittingYarnsAsync(int knittingIEDId, List<KnittingYarn> entities)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<KnittingYarn>().Where(s => s.KnittingIEDId == knittingIEDId).ExecuteDeleteAsync();
                    await _dbContext.Set<KnittingYarn>().AddRangeAsync(entities);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new ApiException($"Updating failed. {ex.InnerException?.Message}");
                }
            }
        }
    }
}
