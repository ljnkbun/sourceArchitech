using FluentValidation;
using Shopfloor.Master.Application.Command.CalendarDetails;

namespace Shopfloor.Master.Application.Validations.CalendarDetails
{
    public class UpdateCalendarDetailCommandValidator : AbstractValidator<UpdateCalendarDetailCommand>
    {
        public UpdateCalendarDetailCommandValidator()
        {
            RuleFor(p => p.DayOfWeek)
                .IsInEnum().WithMessage("{PropertyName} is in enum.");

            RuleFor(p => p.Shift)
                .IsInEnum().WithMessage("{PropertyName} is in enum.");
        }
    }
}
