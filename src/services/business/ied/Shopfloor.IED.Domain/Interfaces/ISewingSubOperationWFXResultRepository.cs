using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingSubOperationWFXResultRepository : IGenericRepositoryAsync<SewingSubOperationWFXResult>
    {
        Task<List<SewingSubOperationWFXResult>> GetSewingSubOperationWFXResultsAsync(int sewingSubOperationWFXId);
        Task UpdateSewingSubOperationWFXResultAsync(int sewingSubOperationWFXId, List<SewingSubOperationWFXResult> entities);
    }
}
