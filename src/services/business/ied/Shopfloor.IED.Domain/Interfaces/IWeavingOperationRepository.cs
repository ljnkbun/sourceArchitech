using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingOperationRepository : IGenericRepositoryAsync<WeavingOperation>
    {
        Task<WeavingOperation> GetWeavingOperationByIdAsync(int id);

        Task<bool> IsExistAsync(int id);

        Task<bool> UpdateWeavingOperationAsync(WeavingOperation dataWeavingOperation,
            BaseUpdateEntity<WeavingOperationInputArticle> dataWeavingOperationInputArticle);
    }
}