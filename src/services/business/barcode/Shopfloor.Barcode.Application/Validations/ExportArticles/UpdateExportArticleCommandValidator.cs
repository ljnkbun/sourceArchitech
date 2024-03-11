using FluentValidation;
using Shopfloor.Barcode.Application.Command.ExportArticles;

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

            RuleFor(p => p.LocationId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }

    }
}
