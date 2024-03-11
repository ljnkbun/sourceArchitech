using FluentValidation;
using Shopfloor.Planning.Application.Query.StripFactories;

namespace Shopfloor.Planning.Application.Validations.StripFactories
{
    public class GetStripFactorysQueryValidator : AbstractValidator<GetStripFactoriesQuery>
    {
        public GetStripFactorysQueryValidator()
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
