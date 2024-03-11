using FluentValidation;
using Shopfloor.Planning.Application.Query.FPPOs;

namespace Shopfloor.Planning.Application.Validations.FPPOs
{
    public class GetFPPOQueryValidator : AbstractValidator<GetFPPOsQuery>
    {
        public GetFPPOQueryValidator()
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
