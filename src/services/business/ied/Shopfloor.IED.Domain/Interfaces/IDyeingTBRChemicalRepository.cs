using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBRChemicalRepository : IGenericRepositoryAsync<DyeingTBRChemical>
{
    Task<bool> IsExistAsync(int recipeId);
}