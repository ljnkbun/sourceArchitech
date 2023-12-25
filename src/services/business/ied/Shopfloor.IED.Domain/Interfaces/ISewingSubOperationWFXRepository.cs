using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingSubOperationWFXRepository : IGenericRepositoryAsync<SewingSubOperationWFX>
    {
        Task<SewingSubOperationWFX> GetSewingSubOperationWFXByIdAsync(int id);
        Task UpdateSewingSubOperationWFXAsync(SewingSubOperationWFX sewingSubOperationWFX, List<SewingSubOperationWFXBOL> newSewingSubOperationWFXBOLs);
    }
}
