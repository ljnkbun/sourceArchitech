using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IWfxPOArticleRepository : IGenericRepositoryAsync<WfxPOArticle>
    {
        Task<bool> Existed();
        Task<DateTime> GetLastDate();
        Task<Core.Models.Responses.PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
            where TParam : RequestParameter
            where TModel : class;
        Task SaveWfxPOArticleSync(List<WfxPOArticle> entites);
        Task<ICollection<WfxPOArticle>> GetByArticleCodeOrderRefAsync(string articleCode, string orderRefNum);
        Task<ICollection<WfxPOArticle>> GetByOrderRefsAsync(string[] orderRefNums);
    }
}
