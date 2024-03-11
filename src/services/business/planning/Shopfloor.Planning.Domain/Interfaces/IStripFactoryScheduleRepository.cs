using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IStripFactoryScheduleRepository : IGenericRepositoryAsync<StripFactorySchedule>
    {
        Task<bool> SplitBatchAsync(StripFactorySchedule entity, StripFactory stripFactory);
        Task<StripFactorySchedule> GetStripFactoryScheduleByScheduleId(int stripScheduleId);
        Task<StripFactorySchedule> GetStripFactoryScheduleInculeById(int id);
        Task<IReadOnlyList<TModel>> GetStripFactorySheduleAsync<TModel>(string articleCode)
            where TModel : class;
        Task<PagedResponse<IReadOnlyList<TModel>>> GetStripFactoryScheduleModelPagedReponseAsync<TParam, TModel>(TParam parameter)
            where TModel : class
            where TParam : RequestParameter;

        Task DeleteStripFactorySchedule(StripFactorySchedule entity);
    }
}
