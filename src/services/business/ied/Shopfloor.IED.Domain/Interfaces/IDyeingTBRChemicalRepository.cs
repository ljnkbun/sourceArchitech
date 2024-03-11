using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBRChemicalRepository : IGenericRepositoryAsync<DyeingTBRChemical>
{
    Task<bool> IsExistAsync(int id);

    Task<bool> UpdateDyeingTBRChemicalValueAsync(DyeingTBRChemical dataDyeingTBRTaskUpdate,
        BaseUpdateEntity<DyeingTBRChemicalValue> dataDyeingTBRChemicalValue);

    Task<DyeingTBRChemical> GetWithIncludeByIdAsync(int id);
}