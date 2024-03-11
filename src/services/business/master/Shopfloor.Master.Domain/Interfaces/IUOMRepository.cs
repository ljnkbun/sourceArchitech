using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IUOMRepository : IMasterRepositoryAsync<UOM>
    {
        Task<bool> IsExistAsync(int id);

        Task UpdateUOMAsync(UOM entity, BaseUpdateEntity<ProductGroupUOM> productGroupUOMs);

        Task<UOM> GetWithIncludeByIdAsync(int id);

        Task<PagedResponse<IReadOnlyList<TModel>>> GetUOMPagedResponseAsync<TParam, TModel>(TParam parameter,
            int? articleId, string articleCode) where TParam : RequestParameter where TModel : class;
    }
}