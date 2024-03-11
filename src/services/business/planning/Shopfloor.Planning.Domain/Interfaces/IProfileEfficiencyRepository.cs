using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IProfileEfficiencyRepository : IMasterRepositoryAsync<ProfileEfficiency>
    {
        Task<ProfileEfficiency> GetProfileEfficiencyByIdAsync(int? id = null);
        Task<decimal> GetProfileEfficiencyValueAsync(string category, string productGroup, string subCategory);
        Task UpdateProfileEfficiencyAsync(ProfileEfficiency profileEfficiency, IEnumerable<ProfileEfficiencyDetail> profileEfficiencyDetail);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetProfileEfficiencyModelAsync<TParam, TModel>(TParam parameter)
            where TModel : class
            where TParam : RequestParameter;
    }
}
