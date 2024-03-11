using FluentValidation;
using Shopfloor.Planning.Application.Query.OrderEfficiencies;

namespace Shopfloor.Planning.Application.Validations.OrderEfficiencies
{
    public class GetOrderEfficienciesQueryValidator : AbstractValidator<GetOrderEfficienciesQuery>
    {
        public GetOrderEfficienciesQueryValidator()
        {
            RuleFor(p => p.OCNo)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}
