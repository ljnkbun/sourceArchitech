using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingBorderStyles;

namespace Shopfloor.IED.Application.Validations.WeavingBorderStyles
{
    public class GetWeavingBorderStylesQueryValidator : AbstractValidator<GetWeavingBorderStylesQuery>
    {
        public GetWeavingBorderStylesQueryValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

        }
    }
}
