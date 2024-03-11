using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Domain.Interfaces
{
    public interface IFPPOOutputDetailRepository : IGenericRepositoryAsync<FPPOOutputDetail>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetCustomModelPagedReponseAsync<TParam, TModel>(TParam parameter, string oCNo, string articleName, string jobOrderNo, string batchNo, string fPPONo, decimal? orderQty, string size, string color) where TParam : RequestParameter where TModel : class;
    }
}
