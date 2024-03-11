using FluentValidation;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class CreateImportDetailCommandValidator : AbstractValidator<CreateImportDetailCommand>
    {
        public CreateImportDetailCommandValidator()
        {
            RuleFor(r => r.Color)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(r => r.Size)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(r => r.ArticleName).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.UOM).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(r => r.AriticleBarcodeId).NotEmpty().WithMessage("{PropertyName}  is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(r => r.Shade)
                   .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(r => r.Note).MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
            RuleFor(r => r.Quantity).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
    }

}
