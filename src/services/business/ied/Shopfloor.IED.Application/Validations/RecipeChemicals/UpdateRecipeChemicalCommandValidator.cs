using FluentValidation;
using Shopfloor.IED.Application.Command.RecipeChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.RecipeChemicals
{
    public class UpdateRecipeChemicalCommandValidator : AbstractValidator<UpdateRecipeChemicalCommand>
    {
        private readonly IRecipeTaskRepository _recipeTask;

        public UpdateRecipeChemicalCommandValidator(IRecipeTaskRepository recipeTask)
        {
            _recipeTask = recipeTask;

            RuleFor(p => p.Unit)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ChemicalCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ChemicalName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RecipeTaskId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int recipeTaskId, CancellationToken token)
        {
            return await _recipeTask.IsExistAsync(recipeTaskId);
        }
    }
}