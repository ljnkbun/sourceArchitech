using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Enums;

namespace Shopfloor.Inspection.Domain.Interfaces
{
    public interface IQCRequestRepository : IGenericRepositoryAsync<QCRequest>
    {
        Task<bool> IsUsedAsync(string qcDefineCode);
        Task<QCRequest> GetQCRequesWithDetailByIdAsync(int id, QCScreenType qcScreenType);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetWithDetailPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
         where TModel : class
         where TParam : RequestParameter;
    }
}
