using FluentValidation;
using Shopfloor.Planning.Application.Command.StripSchedulePlanningDetails;

namespace Shopfloor.Planning.Application.Validations.StripSchedulePlanningDetails
{
    public class UpdateStripSchedulePlanningDetailCommandValidator : AbstractValidator<UpdateStripSchedulePlanningDetailCommand>
    {
        public UpdateStripSchedulePlanningDetailCommandValidator()
        {
            RuleFor(p => p.StripScheduleId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.Date)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.Description)
            .MaximumLength(500).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
