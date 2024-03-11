using FluentValidation;
using Shopfloor.Planning.Application.Command.StripScheduleDetails;

namespace Shopfloor.Planning.Application.Validations.StripScheduleDetails
{
    public class UpdateStripScheduleDetailCommandValidator : AbstractValidator<UpdateStripScheduleDetailCommand>
    {
        public UpdateStripScheduleDetailCommandValidator()
        {
            RuleFor(p => p.StripScheduleId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(r => r.Color)
                .NotNull().WithMessage("{PropertyName}  is not null.")
                .MaximumLength(200).WithMessage("{PropertyName}  is max length.");

            RuleFor(r => r.Size)
                .NotNull().WithMessage("{PropertyName}  is not null.")
                .MaximumLength(200).WithMessage("{PropertyName}  is max length.");

            RuleFor(r => r.UOM)
                .NotNull().WithMessage("{PropertyName}  is not null.")
                .MaximumLength(200).WithMessage("{PropertyName}  is max length.");

            RuleFor(r => r.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
    }
}
