using FluentValidation;
using Shopfloor.Material.Application.Query.MaterialRequests;

namespace Shopfloor.Material.Application.Validations.MaterialRequests
{
    public class GetMaterialRequestQueryValidator : AbstractValidator<GetMaterialRequestsQuery>
    {
        public GetMaterialRequestQueryValidator()
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