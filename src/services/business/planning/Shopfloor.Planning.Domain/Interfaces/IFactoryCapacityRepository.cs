using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IFactoryCapacityRepository : IGenericRepositoryAsync<FactoryCapacity>
    {
        Task<List<FactoryCapacity>> GetFactoryCapacityByDate(DateTime? fDate, DateTime? tDate);
        Task<List<TModel>> GetFactoryCapacityModelByDate<TModel>(DateTime? fDate, DateTime? tDate, int? processId, int? factoryId) where TModel : class;
        Task<bool> SaveFactoryCapacitySync(List<FactoryCapacity> entites);
    }
}
