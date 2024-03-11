using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingProcessChemicalRepository : IGenericRepositoryAsync<DyeingProcessChemical>
{
    Task<bool> IsExistAsync(int id);
}