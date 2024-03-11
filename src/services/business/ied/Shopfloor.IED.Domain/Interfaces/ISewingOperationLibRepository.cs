using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingOperationLibRepository : IMasterRepositoryAsync<SewingOperationLib>
    {
        Task<SewingOperationLib> GetSewingOperationLibByIdAsync(int id);
        Task UpdateSewingOperationLibAsync(SewingOperationLib entity, ICollection<SewingOperationLibBOL> bols);

        Task<SewingOperationLib> AddSewingOperationLibAsync(SewingOperationLib entity);
    }
}
