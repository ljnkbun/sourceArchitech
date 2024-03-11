using Shopfloor.Core.Repositories;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Domain.Interfaces
{
    public interface IOrderEfficiencyRepository : IGenericRepositoryAsync<OrderEfficiency>
    {
        Task<OrderEfficiency> GetOrderEfficiencyByIdAsync(int? id = null);
        Task<decimal> GetOrderEfficiencyValueAsync(string ocNo);
    }
}
