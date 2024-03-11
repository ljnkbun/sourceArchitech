using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Domain.Interfaces
{
    public interface ICalendarRepository : IMasterRepositoryAsync<Calendar>
    {
        Task UpdateProfileEfficiencyAsync(Calendar calendar, IEnumerable<CalendarDetail> calendarDetails);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetCalendarModelAsync<TParam, TModel>(TParam parameter)
            where TModel : class
            where TParam : RequestParameter;

        Task<IReadOnlyList<Calendar>> GetByIds(List<int> ids);
    }
}
