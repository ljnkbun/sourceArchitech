using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingFeatureLibRepository : IMasterRepositoryAsync<SewingFeatureLib>
    {
        Task<SewingFeatureLib> GetSewingFeatureLibByIdAsync(int id);
        Task UpdateSewingFeatureLibAsync(SewingFeatureLib entity, List<SewingFeatureLibBOL> insertItems, List<SewingFeatureLibBOL> deleteItems);
        Task<SewingFeatureLib> AddSewingFeatureLibAsync(SewingFeatureLib entity);
    }
}
