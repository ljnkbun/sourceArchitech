using FluentValidation;
using Shopfloor.IED.Application.Command.RecipeTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.RecipeTasks
{
    public class CreateRecipeTaskCommandValidator : AbstractValidator<CreateRecipeTaskCommand>
    {
        private readonly IRecipeRepository _recipe;

        public CreateRecipeTaskCommandValidator(IRecipeRepository recipe)
        {
            _recipe = recipe;

            RuleFor(p => p.DyeingOperationName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingProcessName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.MachineName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingOperationCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.DyeingProcessCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.MachineCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.RecipeId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");

            RuleForEach(p => p.RecipeChemical).ChildRules(childRecipeChemical =>
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

                childRecipeChemical.RuleFor(p => p.ChemicalSubcategory)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            });
        }

        private async Task<bool> IsExistAsync(int recipeId, CancellationToken token)
        {
            return await _recipe.IsExistAsync(recipeId);
        }
    }
}