using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingOperationLibBOLRepository : IGenericRepositoryAsync<SewingOperationLibBOL>
    {
        Task<List<SewingOperationLibBOL>> GetListAsync(int sewingOperationLibId);
    }
}
