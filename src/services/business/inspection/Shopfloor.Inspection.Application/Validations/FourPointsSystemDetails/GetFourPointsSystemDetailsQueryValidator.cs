using FluentValidation;
using Shopfloor.Inspection.Application.Query.FourPointsSystemDetails;

namespace Shopfloor.Inspection.Application.Validations.FourPointsSystemDetails
{
    public class GetFourPointsSystemDetailsQueryValidator : AbstractValidator<GetFourPointsSystemDetailsQuery>
    {
        public GetFourPointsSystemDetailsQueryValidator()
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
