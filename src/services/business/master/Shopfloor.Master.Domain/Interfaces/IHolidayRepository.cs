using Shopfloor.Master.Domain.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface IHolidayRepository : IGenericRepositoryAsync<Holiday>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetHolidayModelPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fDate, DateTime? tDate) where TModel : class where TParam : RequestParameter;
    }
}
