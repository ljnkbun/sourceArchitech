using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IStripScheduleRepository : IGenericRepositoryAsync<StripSchedule>
    {
        Task<bool> SaveRangeStripSchedule(List<StripSchedule> stripSchedules);
        Task<PagedResponse<IReadOnlyList<TModel>>> GetStripScheduleModelAsync<TParam, TModel>(TParam parameter)
            where TModel : class
            where TParam : RequestParameter;
        Task<Response<IReadOnlyList<TModel>>> GetStripSheduleAsync<TModel>(string articleCode)
            where TModel : class;

        Task DeleteSplitBatchOrNotAsync(StripSchedule stripSchedule, StripFactorySchedule stripFactorySchedule);
        Task<StripSchedule> GetByIdAsNo(int id);
        Task<ICollection<StripSchedule>> GetStripScheduleByListId(List<int> ids);
        Task<ICollection<StripSchedule>> GetStripScheduleByMachineIdAsync(int id);
        Task<ICollection<StripSchedule>> GetStripScheduleByLineIdAsync(int id);
        Task<ICollection<StripSchedule>> GetStripScheduleForCalculate(int? lineId, int? machineId, DateTime fDate, DateTime tDate);
        Task<List<StripSchedule>> GetStripScheduleByPars(List<int> machineIds, List<int> lineIds, DateTime fDate, DateTime tDate);
    }
}
