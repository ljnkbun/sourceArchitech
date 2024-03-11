using FluentValidation;
using Shopfloor.IED.Application.Command.Recipes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Recipes
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        private readonly IDyeingTBRecipeRepository _dyeingTbRecipe;

        public CreateRecipeCommandValidator(IDyeingTBRecipeRepository dyeingTbRecipe)
        {
            _dyeingTbRecipe = dyeingTbRecipe;

            RuleFor(p => p.JobDate)
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.TCFNO)
             .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
           .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Style)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.FabricCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.FabricName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Color)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.LotNo)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RollKg)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Speed)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.NozzleA)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.NozzleB)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Method)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.LAB)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.InCharge)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Manager)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingTBRecipeId)
                .MustAsync(IsExistDyeingTBRecipeAsync)
                .WithMessage("{PropertyName} not found.");
            
            RuleForEach(p => p.RecipeTask).ChildRules(childRecipeTask =>
            {
                childRecipeTask.RuleFor(p => p.DyeingOperationName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childRecipeTask.RuleFor(p => p.DyeingProcessName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childRecipeTask.RuleFor(p => p.MachineCode)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childRecipeTask.RuleFor(p => p.MachineName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childRecipeTask.RuleForEach(p => p.RecipeChemical).ChildRules(childRecipeChemical =>
                {
                    childRecipeChemical.RuleFor(p => p.Unit)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull()
                        .MaximumLength(250).WithMessage("{PropertyName} must not exceed 50 characters.");

                    childRecipeChemical.RuleFor(p => p.ChemicalCode)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull()
                        .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                    childRecipeChemical.RuleFor(p => p.ChemicalName)
                        .NotEmpty().WithMessage("{PropertyName} is required.")
                        .NotNull()
                        .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
                });
            });
        }

        private async Task<bool> IsExistDyeingTBRecipeAsync(int dyeingTBRecipeId, CancellationToken token)
        {
            return await _dyeingTbRecipe.IsExistAsync(dyeingTBRecipeId);
        }
    }
}