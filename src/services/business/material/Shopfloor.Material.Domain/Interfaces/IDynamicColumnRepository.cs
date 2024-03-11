using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Domain.Interfaces
{
    public interface IDynamicColumnRepository : IGenericRepositoryAsync<DynamicColumn>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetDynamicColumnPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
            where TModel : class
            where TParam : RequestParameter;

        Task<bool> UpdateDynamicColumnAsync(DynamicColumn datalUpdate,
            BaseUpdateEntity<DynamicColumnContent> dataDynamicColumnContent);

        Task<DynamicColumn> GetWithIncludeByIdAsync(int id);

        Task<bool> IsUniqueAsync(string code, string category, int? id = null);

        Task<List<DynamicColumn>> GetListByCodeAsync(Dictionary<string, string> data, string type);

        Task<List<DynamicColumn>> GetDynamicColumnByCodesAsync(string[] codes, string type);
    }
}