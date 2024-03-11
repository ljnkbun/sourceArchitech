using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBMaterialColors;

namespace Shopfloor.IED.Application.Validations.DyeingTBMaterialColors
{
    public class GetDyeingTBMaterialColorsQueryValidator : AbstractValidator<GetDyeingTBMaterialColorsQuery>
    {
        public GetDyeingTBMaterialColorsQueryValidator()
        {
            RuleFor(p => p.Color)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Pantone)
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