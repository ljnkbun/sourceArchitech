using FluentValidation;
using Shopfloor.Planning.Application.Query.StripScheduleDetails;

namespace Shopfloor.Planning.Application.Validations.StripScheduleDetails
{
    public class GetStripScheduleDetailsQueryValidator : AbstractValidator<GetStripScheduleDetailsQuery>
    {
        public GetStripScheduleDetailsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}
