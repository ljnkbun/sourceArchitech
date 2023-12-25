using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingFeatureLibBOLRepository : IGenericRepositoryAsync<SewingFeatureLibBOL>
    {
        Task<List<SewingFeatureLibBOL>> GetListAsync(int sewingFeatureLibId);
    }
}
