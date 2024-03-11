using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBRChemicalValueRepository : IGenericRepositoryAsync<DyeingTBRChemicalValue>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingTBRChemicalValue> GetWithIncludeByIdAsync(int id);

    Task<bool> IsExistByRecipeIdAsync(int id, int version);
}