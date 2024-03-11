using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces
{
    public interface ILiquorRatioRepository : IGenericRepositoryAsync<LiquorRatio>
    {
        Task<bool> IsValueUniqueAsync(decimal value, int? id = null);
    }
}
