using FluentValidation;
using Shopfloor.Planning.Application.Query.StripSchedules;

namespace Shopfloor.Planning.Application.Validations.StripSchedules
{
    public class GetStripSchedulesQueryValidator : AbstractValidator<GetStripSchedulesQuery>
    {
        public GetStripSchedulesQueryValidator()
        {
            RuleFor(p => p.FromDate)
                .LessThan(DateTime.Now.AddDays(1));

            RuleFor(p => p.ToDate)
                .LessThan(DateTime.Now.AddDays(1));

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
