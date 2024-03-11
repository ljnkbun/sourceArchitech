using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IOperationLibraryRepository : IMasterRepositoryAsync<OperationLibrary>
    {
        Task<bool> InsertUpdateList(IEnumerable<OperationLibrary> lstAdd, List<OperationLibrary> lstUpdate);
    }
}
