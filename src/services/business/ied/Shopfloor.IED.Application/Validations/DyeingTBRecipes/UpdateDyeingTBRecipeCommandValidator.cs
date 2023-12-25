using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRecipes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRecipes
{
    public class UpdateDyeingTBRecipeCommandValidator : AbstractValidator<UpdateDyeingTBRecipeCommand>
    {
        private readonly IDyeingTBMaterialColorRepository _dyeingTBRecipe;

        public UpdateDyeingTBRecipeCommandValidator(IDyeingTBMaterialColorRepository dyeingTBRecipe)
        {
            _dyeingTBRecipe = dyeingTBRecipe;

            RuleFor(p => p.TemplateName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.TCFNo)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Comment)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.BuyerRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.GarmentStyleRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Color)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Concentration)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
                        
            RuleFor(p => p.VersionQty)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 0.")
                .LessThanOrEqualTo(24).WithMessage("{PropertyName} must less than 24.");

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.DyeingTBMaterialColorId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingTbMaterialColorId, CancellationToken token)
        {
            return await _dyeingTBRecipe.IsExistAsync(dyeingTbMaterialColorId);
        }
    }
}