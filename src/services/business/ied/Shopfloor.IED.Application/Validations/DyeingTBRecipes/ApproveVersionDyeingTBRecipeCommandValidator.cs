using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRecipes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRecipes
{
    public class ApproveVersionDyeingTBRecipeCommandValidator : AbstractValidator<ApproveVersionDyeingTBRecipeCommand>
    {
        private readonly IDyeingTBRChemicalValueRepository _dyeingTbrChemicalValue;

        private readonly IDyeingTBRecipeRepository _dyeingTbRecipe;

        public ApproveVersionDyeingTBRecipeCommandValidator(IDyeingTBRChemicalValueRepository dyeingTbrChemicalValue, IDyeingTBRecipeRepository dyeingTbRecipe)
        {
            _dyeingTbrChemicalValue = dyeingTbrChemicalValue;
            _dyeingTbRecipe = dyeingTbRecipe;

            RuleFor(p => p)
                .MustAsync(IsExistValueByRecipeIdAsync)
                .WithMessage("Version in recipe not found.");

            RuleFor(p => p.Id)
                .MustAsync(IsExistDyeingTbRecipeIdAsync)
                .WithMessage("Recipe not found.");
        }

        private async Task<bool> IsExistValueByRecipeIdAsync(ApproveVersionDyeingTBRecipeCommand command, CancellationToken token)
        {
            return await _dyeingTbrChemicalValue.IsExistByRecipeIdAsync(command.Id, command.ApproveVersionIndex);
        }

        private async Task<bool> IsExistDyeingTbRecipeIdAsync(int dyeingTbRecipeId, CancellationToken token)
        {
            return await _dyeingTbRecipe.IsExistAsync(dyeingTbRecipeId);
        }
    }
}