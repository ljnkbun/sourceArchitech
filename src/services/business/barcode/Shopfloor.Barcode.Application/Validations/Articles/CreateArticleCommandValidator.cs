using FluentValidation;
using Shopfloor.Barcode.Application.Command.Articles;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Articles
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        IArticleRepository _repository;
        public CreateArticleCommandValidator(IArticleRepository repository)
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
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
