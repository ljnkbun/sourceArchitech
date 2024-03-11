using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingRoutingRepository : IGenericRepositoryAsync<WeavingRouting>
    {
        Task<bool> IsExistAsync(int id);

        Task<bool> UpdateWeavingRoutingAsync(WeavingRouting dataWeavingRouting,
            BaseUpdateEntity<WeavingOperation> dataWeavingOperation,
            BaseUpdateEntity<WeavingOperationInputArticle> dataWeavingOperationInputArticle);

        Task<WeavingRouting> GetWithIncludeByIdAsync(int id);

        Task UpdateWeavingRoutingsAsync(int weavingIEDId, List<WeavingRouting> entities);
    }
}