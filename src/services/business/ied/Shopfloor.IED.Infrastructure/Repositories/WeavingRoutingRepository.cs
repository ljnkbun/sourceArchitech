using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingRoutingRepository : GenericRepositoryAsync<WeavingRouting>, IWeavingRoutingRepository
    {
        public WeavingRoutingRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<WeavingRouting>().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateWeavingRoutingAsync(WeavingRouting dataWeavingRouting, BaseUpdateEntity<WeavingOperation> dataWeavingOperation, BaseUpdateEntity<WeavingOperationInputArticle> dataWeavingOperationInputArticle)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<WeavingOperationInputArticle>().RemoveRange(dataWeavingOperationInputArticle.LstDataDelete);
                    _dbContext.Set<WeavingOperation>().RemoveRange(dataWeavingOperation.LstDataDelete);

                    _dbContext.Set<WeavingOperation>().AddRange(dataWeavingOperation.LstDataAdd);
                    _dbContext.Set<WeavingOperationInputArticle>().AddRange(dataWeavingOperationInputArticle.LstDataAdd);

                    _dbContext.Update(dataWeavingRouting);
                    _dbContext.Set<WeavingOperation>().UpdateRange(dataWeavingOperation.LstDataUpdate);
                    _dbContext.Set<WeavingOperationInputArticle>().UpdateRange(dataWeavingOperationInputArticle.LstDataUpdate);
                    await _dbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    result = false;
                    await transaction.RollbackAsync();
                }
            }
            return result;
        }

        public async Task<WeavingRouting> GetWithIncludeByIdAsync(int id) => await _dbContext.Set<WeavingRouting>()
            .Include(x => x.WeavingOperations)
            .ThenInclude(x => x.WeavingOperationInputArticles)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateWeavingRoutingsAsync(int weavingIEDId, List<WeavingRouting> entities)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.Set<WeavingRouting>().Where(s => s.WeavingIEDId == weavingIEDId).ExecuteDeleteAsync();
                    await _dbContext.Set<WeavingRouting>().AddRangeAsync(entities);
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