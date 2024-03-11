using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingRoutingRepository : IGenericRepositoryAsync<DyeingRouting>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingRouting> GetWithIncludeByIdAsync(int id);
    Task UpdateDyeingRoutingsAsync(int dyeingIEDId, List<DyeingRouting> entities);
}