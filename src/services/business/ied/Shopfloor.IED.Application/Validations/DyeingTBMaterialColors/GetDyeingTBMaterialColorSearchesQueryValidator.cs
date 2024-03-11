using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBMaterialColors;

namespace Shopfloor.IED.Application.Validations.DyeingTBMaterialColorSearches
{
    public class GetDyeingTBMaterialColorSearchesQueryValidator : AbstractValidator<GetDyeingTBMaterialColorSearchesQuery>
    {
        public GetDyeingTBMaterialColorSearchesQueryValidator()
        {
            RuleFor(p => p.RequestNo)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ArticleCode)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}