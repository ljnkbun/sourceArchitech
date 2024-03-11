using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBRecipes;

namespace Shopfloor.IED.Application.Validations.DyeingTBRecipes
{
    public class GetDyeingTBRecipesQueryValidator : AbstractValidator<GetDyeingTBRecipesQuery>
    {
        public GetDyeingTBRecipesQueryValidator()
        {         
            RuleFor(p => p.TBRecipeNo)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.TemplateName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.TCFNo)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
                        
            RuleFor(p => p.VersionQty)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 0.")
                .LessThanOrEqualTo(24).WithMessage("{PropertyName} must less than 24.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}