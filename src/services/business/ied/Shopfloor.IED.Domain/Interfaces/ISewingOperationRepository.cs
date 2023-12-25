using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingOperationRepository : IMasterRepositoryAsync<SewingOperation>
    {
        Task<SewingOperation> GetSewingOperationByIdAsync(int id);
        Task UpdateSewingOperationAsync(SewingOperation sewingOperation, List<SewingOperationBOL> newSewingOperationBOLs);
    }
}
