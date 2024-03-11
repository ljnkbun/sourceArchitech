using FluentValidation;
using Shopfloor.Master.Application.Query.CalendarDetails;

namespace Shopfloor.Master.Application.Validations.CalendarDetails
{
    public class GetCalendarDetailsQueryValidator : AbstractValidator<GetCalendarDetailsQuery>
    {
        public GetCalendarDetailsQueryValidator()
        {
            RuleFor(p => p.DayOfWeek)
                .IsInEnum().WithMessage("{PropertyName} is in enum.");

            RuleFor(p => p.Shift)
                .IsInEnum().WithMessage("{PropertyName} is in enum.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}
