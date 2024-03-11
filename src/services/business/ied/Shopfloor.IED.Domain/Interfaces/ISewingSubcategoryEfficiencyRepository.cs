using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ISewingSubcategoryEfficiencyRepository : IGenericRepositoryAsync<SewingSubcategoryEfficiency>
    {
        Task<bool> IsExistAsync(int id);

        Task<bool> IsUniqueSubCategoryAsync(string subCategory, int? id = null);
    }
}