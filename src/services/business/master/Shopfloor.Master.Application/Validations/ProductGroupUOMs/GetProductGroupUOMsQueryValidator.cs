using FluentValidation;
using Shopfloor.Master.Application.Query.ProductGroupUOMs;

namespace Shopfloor.Master.Application.Validations.ProductGroupUOMs
{
    public class GetProductGroupUOMsQueryValidator : AbstractValidator<GetProductGroupUOMsQuery>
    {
        public GetProductGroupUOMsQueryValidator()
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