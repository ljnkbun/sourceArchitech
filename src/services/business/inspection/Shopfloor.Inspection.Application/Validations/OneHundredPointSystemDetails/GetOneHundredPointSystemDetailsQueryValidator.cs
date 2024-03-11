using FluentValidation;
using Shopfloor.Inspection.Application.Query.OneHundredPointSystemDetails;

namespace Shopfloor.Inspection.Application.Validations.OneHundredPointSystemDetails
{
    public class GetOneHundredPointSystemDetailsQueryValidator : AbstractValidator<GetOneHundredPointSystemDetailsQuery>
    {
        public GetOneHundredPointSystemDetailsQueryValidator()
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
