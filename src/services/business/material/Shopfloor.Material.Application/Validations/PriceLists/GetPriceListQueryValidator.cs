using FluentValidation;
using Shopfloor.Material.Application.Query.PriceLists;

namespace Shopfloor.Material.Application.Validations.PriceLists
{
    public class GetPriceListQueryValidator : AbstractValidator<GetPriceListsQuery>
    {
        public GetPriceListQueryValidator()
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