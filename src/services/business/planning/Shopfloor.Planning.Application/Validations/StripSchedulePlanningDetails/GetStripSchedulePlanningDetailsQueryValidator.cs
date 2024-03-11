using FluentValidation;
using Shopfloor.Planning.Application.Query.StripSchedulePlanningDetails;

namespace Shopfloor.Planning.Application.Validations.StripSchedulePlanningDetails
{
    public class GetStripSchedulePlanningDetailsQueryValidator : AbstractValidator<GetStripSchedulePlanningDetailsQuery>
    {
        public GetStripSchedulePlanningDetailsQueryValidator()
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
