using FluentValidation;
using Shopfloor.Barcode.Application.Command.ExportDetails;

namespace Shopfloor.Barcode.Application.Validations.ExportDetails
{
    public class UpdateExportDetailCommandValidator : AbstractValidator<UpdateExportDetailCommand>
    {

        public UpdateExportDetailCommandValidator()
        {

            RuleFor(p => p.Status)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.LocationId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.UOM)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Shade)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.OC)
              .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Location)
              .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Note)
            .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

        }

    }
}
