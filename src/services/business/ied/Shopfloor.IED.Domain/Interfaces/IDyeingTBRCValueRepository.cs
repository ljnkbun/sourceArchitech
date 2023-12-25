using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBRCValueRepository : IGenericRepositoryAsync<DyeingTBRCValue>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingTBRCValue> GetWithIncludeByIdAsync(int id);
}