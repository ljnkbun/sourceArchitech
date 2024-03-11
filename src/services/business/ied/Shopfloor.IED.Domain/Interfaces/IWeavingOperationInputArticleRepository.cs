using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface IWeavingOperationInputArticleRepository : IGenericRepositoryAsync<WeavingOperationInputArticle>
    {
        Task<bool> IsExistAsync(int id);
    }
}