using FluentValidation;
using Shopfloor.Barcode.Application.Command.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.ArticleBarcodes
{
    public class UpdateArticleBarcodeCommandValidator : AbstractValidator<UpdateArticleBarcodeCommand>
    {
        private readonly IArticleBarcodeRepository _repository;
        public UpdateArticleBarcodeCommandValidator(IArticleBarcodeRepository repository)
        {
            _repository = repository;

            RuleFor(r => r.ArticleName).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Quantity).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.NumberOfCone).GreaterThan(0).WithMessage("{PropertyName} must be null or greater than 0.");
            RuleFor(r => r.WeightPerCone).GreaterThan(0).WithMessage("{PropertyName} must be null or greater than 0.");

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueBarcodeAsync).WithMessage("{PropertyName} must unique.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }

        private async Task<bool> IsUniqueBarcodeAsync(string barcode, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueBarcodeAsync(barcode);
        }
    }
}
