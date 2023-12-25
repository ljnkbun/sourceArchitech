using FluentValidation;
using Shopfloor.Barcode.Application.Command.Articles;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Articles
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        private readonly IArticleRepository _repository;
        public UpdateArticleCommandValidator(IArticleRepository repository)
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

            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }
        private async Task<bool> IsUniqueAsync(UpdateArticleCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
