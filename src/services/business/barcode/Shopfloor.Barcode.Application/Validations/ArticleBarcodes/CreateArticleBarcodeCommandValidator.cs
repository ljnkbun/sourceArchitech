using FluentValidation;
using Shopfloor.Barcode.Application.Command.ArticleBarcodes;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.ArticleBarcodes
{
    public class CreateArticleBarcodeCommandValidator : AbstractValidator<CreateArticleBarcodeCommand>
    {
        private readonly IArticleBarcodeRepository _repository;
        public CreateArticleBarcodeCommandValidator(IArticleBarcodeRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.CurrentLocationId)
                .GreaterThan(0).WithMessage("{PropertyName} is GreaterThan.");

            RuleFor(r => r.Color).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Size).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleName).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.UOM).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.OC).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Shade).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Note).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Quantity).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.NumberOfCone).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.WeightPerCone).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Unit).NotEmpty().WithMessage("{PropertyName}  is required.");

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
