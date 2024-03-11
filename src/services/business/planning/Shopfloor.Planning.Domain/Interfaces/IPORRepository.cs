using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IPORRepository : IGenericRepositoryAsync<POR>
    {
        Task<List<POR>> GetWfxPORByIdsAsync(List<int> ids);
        Task<List<int>> GetByArticleCode(string articleCode);
        Task<POR> MergePORAsync(ICollection<POR> mergePOR);
        Task<POR> SplitPORAsync(POR entity, List<PORDetail> pORDetails);
        Task<bool> CheckAnyArticleCodeInPor(string articleCode);
        Task<bool> SaveWfxPORSync(List<POR> entities);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedReponseIsRemainingAsync<TParam, TModel>(TParam parameter, bool? isRemaining)
            where TModel : class
            where TParam : RequestParameter;
        Task<POR> AddJobOrderNoRequestAsync(POR entity);
    }
}
