using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingOperationWFXRepository : IGenericRepositoryAsync<SewingOperationWFX>
    {
        Task<SewingOperationWFX> GetSewingOperationWFXAsync(int id, int version);
        Task AddSewingOperationWFXAsync(SewingOperationWFX entity);
        Task AddVersionAsync(int sewingOperationWFXId);
        Task<List<SewingOperationWFXVersion>> GetVersionsAsync(int sewingOperationWFXId);
    }
}
