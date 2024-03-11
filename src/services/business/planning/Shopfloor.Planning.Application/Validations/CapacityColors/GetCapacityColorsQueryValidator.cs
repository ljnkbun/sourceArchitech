using FluentValidation;
using Shopfloor.Planning.Application.Query.CapacityColors;

namespace Shopfloor.Planning.Application.Validations.CapacityColors
{
    public class GetCapacityColorsQueryValidator : AbstractValidator<GetCapacityColorsQuery>
    {
        public GetCapacityColorsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
            RuleFor(p => p.Color).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        }
    }
}
