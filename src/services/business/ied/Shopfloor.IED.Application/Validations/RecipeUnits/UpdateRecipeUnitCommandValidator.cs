using FluentValidation;
using Shopfloor.IED.Application.Command.RecipeUnits;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.RecipeUnits
{
    public class UpdateRecipeUnitCommandValidator : AbstractValidator<UpdateRecipeUnitCommand>
    {
        private readonly IRecipeUnitRepository _recipeUnitRepository;
        public UpdateRecipeUnitCommandValidator(IRecipeUnitRepository recipeUnitRepository)
        {
            _recipeUnitRepository = recipeUnitRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }
        private async Task<bool> IsUniqueAsync(UpdateRecipeUnitCommand command, CancellationToken token)
        {
            return await _recipeUnitRepository.IsNameUniqueAsync(command.Name, command.Id);
        }
    }
}
