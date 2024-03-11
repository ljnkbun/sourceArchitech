using AutoMapper;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class OperationLibraryRepository : MasterRepositoryAsync<OperationLibrary>, IOperationLibraryRepository
    {
        public OperationLibraryRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<bool> InsertUpdateList(IEnumerable<OperationLibrary> lstAdd, List<OperationLibrary> lstUpdate)
        {
            bool result = true;
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _dbContext.Set<OperationLibrary>().AddRange(lstAdd);
                    _dbContext.Set<OperationLibrary>().UpdateRange(lstUpdate);
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
