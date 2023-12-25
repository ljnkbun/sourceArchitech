using FluentValidation;

using Shopfloor.Material.Application.Query.DynamicColumns;

namespace Shopfloor.Material.Application.Validations.DynamicColumns
{
    public class GetDynamicColumnQueryValidator : AbstractValidator<GetDynamicColumnsQuery>
    {
        public GetDynamicColumnQueryValidator()
        {
            RuleFor(p => p.Code)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CategoryCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.DisplayIndex)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");
        }
    }
}