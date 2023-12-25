using FluentValidation;
using Shopfloor.Barcode.Application.Command.ExportArticles;
using Shopfloor.Barcode.Application.Validations.ExportDetails;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.ExportArticles
{
    public class UpdateExportArticleCommandValidator : AbstractValidator<UpdateExportArticleCommand>
    {

        public UpdateExportArticleCommandValidator()
        {
            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Quantity)
               .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

            RuleFor(p => p.UOM)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.LotNo)
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }

    }
}
