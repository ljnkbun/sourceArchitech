using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingOperationLibResultRepository : IGenericRepositoryAsync<SewingOperationLibResult>
    {
        Task<List<SewingOperationLibResult>> GetSewingOperationLibResultsAsync(int SewingOperationLibId);
        Task UpdateSewingOperationLibResultAsync(int SewingOperationLibId, List<SewingOperationLibResult> entities);
    }
}
