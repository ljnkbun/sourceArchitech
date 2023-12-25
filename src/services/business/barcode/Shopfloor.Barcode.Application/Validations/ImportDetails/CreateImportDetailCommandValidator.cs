using FluentValidation;
using Shopfloor.Barcode.Application.Command.ImportDetails;
using Shopfloor.Barcode.Domain.Constants;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class CreateImportDetailCommandValidator : AbstractValidator<CreateImportDetailCommand>
    {
        public CreateImportDetailCommandValidator()
        {
            RuleFor(r => r.Color).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Size).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleName).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ArticleCode).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.AriticleBarcodeId).NotEmpty().WithMessage("{PropertyName}  is required.").When(y => y.Type == ImportType.ImportTransferToSite);
            RuleFor(r => r.UOM).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Shade).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Note).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Quantity).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.NumberOfCone).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.WeightPerCone).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Unit).NotEmpty().WithMessage("{PropertyName}  is required.");
        }
    }

}
