using FluentValidation;
using Shopfloor.IED.Application.Command.RecipeCategories;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.RecipeCategories
{
    public class UpdateRecipeCategoryCommandValidator : AbstractValidator<UpdateRecipeCategoryCommand>
    {
        private readonly IRecipeCategoryRepository _repository;
        public UpdateRecipeCategoryCommandValidator(IRecipeCategoryRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateRecipeCategoryCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
