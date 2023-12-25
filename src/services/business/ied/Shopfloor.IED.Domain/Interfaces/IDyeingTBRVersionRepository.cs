using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBRVersionRepository : IGenericRepositoryAsync<DyeingTBRVersion>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingTBRVersion> GetWithIncludeByIdAsync(int id);
}