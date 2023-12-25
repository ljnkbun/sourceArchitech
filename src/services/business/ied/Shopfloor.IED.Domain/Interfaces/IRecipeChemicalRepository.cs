﻿using Shopfloor.Core.Repositories;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Domain.Interfaces;

public interface IRecipeChemicalRepository : IGenericRepositoryAsync<RecipeChemical>
{
    Task<bool> IsExistAsync(int id);
}