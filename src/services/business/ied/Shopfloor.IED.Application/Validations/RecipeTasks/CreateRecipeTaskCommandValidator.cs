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

            RuleFor(p => p.DyeingOpreation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.MachineType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RecipeId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int recipeId, CancellationToken token)
        {
            return await _recipe.IsExistAsync(recipeId);
        }
    }
}