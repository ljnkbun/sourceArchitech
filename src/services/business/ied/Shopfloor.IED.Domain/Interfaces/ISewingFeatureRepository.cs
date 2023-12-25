using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingFeatureRepository : IMasterRepositoryAsync<SewingFeature>
    {
        Task<SewingFeature> GetSewingFeatureByIdAsync(int id);
        Task UpdateSewingFeatureAsync(SewingFeature sewingFeature, List<SewingFeatureBOL> newSewingFeatureBOLs);
    }
}
