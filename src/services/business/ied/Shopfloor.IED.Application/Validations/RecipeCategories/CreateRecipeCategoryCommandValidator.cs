using FluentValidation;
using Shopfloor.IED.Application.Command.RecipeCategories;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.RecipeCategories
{
    public class CreateRecipeCategoryCommandValidator : AbstractValidator<CreateRecipeCategoryCommand>
    {
        private readonly IRecipeCategoryRepository _repository;
        public CreateRecipeCategoryCommandValidator(IRecipeCategoryRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
