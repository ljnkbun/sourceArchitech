using FluentValidation;
using Shopfloor.IED.Application.Query.RequestDivisions;

namespace Shopfloor.IED.Application.Validations.RequestDivisions
{
    public class GetRequestDivisionsQueryValidator : AbstractValidator<GetRequestDivisionsQuery>
    {
        public GetRequestDivisionsQueryValidator()
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
