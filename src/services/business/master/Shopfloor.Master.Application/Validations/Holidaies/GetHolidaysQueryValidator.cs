using FluentValidation;
using Shopfloor.Master.Application.Query.Holidays;

namespace Shopfloor.Master.Application.Validations.Holidays
{
    public class GetHolidaysQueryValidator : AbstractValidator<GetHolidaysQuery>
    {
        public GetHolidaysQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
            RuleFor(p => p.Description).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
