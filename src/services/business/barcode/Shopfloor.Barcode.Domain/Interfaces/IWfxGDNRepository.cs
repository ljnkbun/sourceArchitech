using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IWfxGDNRepository : IGenericRepositoryAsync<WfxGDN>
    {
        Task<bool> Existed();
        Task<List<WfxGDN>> GetByArticleCodeGDNNumAsync(string wfxArticleCode, string GDNNum);
        Task<DateTime> GetLastDate();
        Task<Core.Models.Responses.PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
            where TParam : RequestParameter
            where TModel : class;
        Task SaveWfxGDNSync(List<WfxGDN> entites);
    }

}
