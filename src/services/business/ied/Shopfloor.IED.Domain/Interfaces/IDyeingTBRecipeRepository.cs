using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IDyeingTBRecipeRepository : IGenericRepositoryAsync<DyeingTBRecipe>
{
    Task<bool> IsExistAsync(int id);

    Task<DyeingTBRecipe> GetWithIncludeByIdAsync(int id);

    Task<DyeingTBRecipe> AddDyeingTBRecipeAsync(DyeingTBRecipe entity);

    Task<DyeingTBRecipe> GetWithIncludeByColorIdAsync(int dyeingTbMaterialColorId);

    Task<DyeingTBRecipe> GetParentWithIncludeByIdAsync(int id);

    Task<bool> UpdateDyeingTBRecipeAsync(DyeingTBRecipe dataDyeingTBRecipeUpdate, BaseUpdateEntity<DyeingTBRTask> dataDyeingTBRTask, BaseUpdateEntity<DyeingTBRChemical> dataDyeingTBRChemical, BaseUpdateEntity<DyeingTBRChemicalValue> dataDyeingTBRChemicalValue);
}