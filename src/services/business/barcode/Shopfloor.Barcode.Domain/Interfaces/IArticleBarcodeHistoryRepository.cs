using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface IArticleBarcodeHistoryRepository : IGenericRepositoryAsync<ArticleBarcodeHistory>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, string ids) where TParam : RequestParameter where TModel : class;
    }
}
