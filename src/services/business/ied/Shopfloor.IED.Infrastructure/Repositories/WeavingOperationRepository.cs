using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;

namespace Shopfloor.IED.Infrastructure.Repositories
{
    public class WeavingOperationRepository : GenericRepositoryAsync<WeavingOperation>, IWeavingOperationRepository
    {
        public WeavingOperationRepository(IEDContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await _dbContext.Set<WeavingOperation>().AnyAsync(x => x.Id == id);
        }

        public async Task<WeavingOperation> GetWeavingOperationByIdAsync(int id)
        {
            return await _dbContext.Set<WeavingOperation>()
                                    .Include(x => x.WeavingOperationInputArticles)
                                    .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> UpdateWeavingOperationAsync(WeavingOperation dataWeavingOperation, BaseUpdateEntity<WeavingOperationInputArticle> dataWeavingOperationInputArticle)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<WeavingOperationInputArticle>().RemoveRange(dataWeavingOperationInputArticle.LstDataDelete);

                    _dbContext.Set<WeavingOperationInputArticle>().AddRange(dataWeavingOperationInputArticle.LstDataAdd);

                    _dbContext.Update(dataWeavingOperation);
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
    }
}