using FluentValidation;
using Shopfloor.Barcode.Application.Command.Imports;
using Shopfloor.Barcode.Application.Validations.ImportArticles;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Imports
{
    public class CreateImportCommandValidator : AbstractValidator<CreateImportCommand>
    {
        private readonly IImportRepository _repository;
        public CreateImportCommandValidator(IImportRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Code)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull()
                           .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                           .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            RuleForEach(x => x.ImportArticles).SetValidator(new CreateImportArticleCommandValidator());

        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
