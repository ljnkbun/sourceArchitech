using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IWfxGDIRepository : IGenericRepositoryAsync<WfxGDI>
    {
        Task<bool> Existed();
        Task<List<WfxGDI>> GetByArticleCodeOrderRefAsync(string articleCode, string orderRefNum, string gDINum);
        Task<List<WfxGDI>> GetByArticleCodesAsync(string[] articleCodes);
        Task<DateTime> GetLastDate();
        Task<Core.Models.Responses.PagedResponse<IReadOnlyList<TModel>>> GetListAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
            where TParam : RequestParameter
            where TModel : class;
        Task SaveWfxGDISync(List<WfxGDI> entites);
    }

}
