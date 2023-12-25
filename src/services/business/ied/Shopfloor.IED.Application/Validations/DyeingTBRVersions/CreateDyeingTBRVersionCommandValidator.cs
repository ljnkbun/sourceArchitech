using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRVersions;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRVersions
{
    public class CreateDyeingTBRVersionCommandValidator : AbstractValidator<CreateDyeingTBRVersionCommand>
    {
        private readonly IDyeingTBRecipeRepository _dyeingTBRecipe;

        public CreateDyeingTBRVersionCommandValidator(IDyeingTBRecipeRepository dyeingTBRecipe)
        {
            _dyeingTBRecipe = dyeingTBRecipe;

            RuleFor(p => p.Version)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 0.")
                .LessThanOrEqualTo(24).WithMessage("{PropertyName} must less than 24.");

            RuleFor(p => p.DyeingTBRecipeId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingTbRecipeId, CancellationToken token)
        {
            return await _dyeingTBRecipe.IsExistAsync(dyeingTbRecipeId);
        }
    }
}