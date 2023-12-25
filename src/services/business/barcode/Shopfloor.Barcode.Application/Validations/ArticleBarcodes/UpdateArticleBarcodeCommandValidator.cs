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
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p)
                .MustAsync(IsUniqueBarcodeAsync).WithMessage("Barcode must unique.");

        }

        private async Task<bool> IsUniqueBarcodeAsync(UpdateArticleBarcodeCommand command, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueBarcodeAsync(command.Barcode);
        }
    }
}
