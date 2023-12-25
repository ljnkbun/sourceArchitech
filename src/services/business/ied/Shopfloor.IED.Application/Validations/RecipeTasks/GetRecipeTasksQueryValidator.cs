using FluentValidation;
using Shopfloor.IED.Application.Query.RecipeTasks;

namespace Shopfloor.IED.Application.Validations.RecipeTasks
{
    public class GetRecipeTasksQueryValidator : AbstractValidator<GetRecipeTasksQuery>
    {
        public GetRecipeTasksQueryValidator()
        {
            RuleFor(p => p.DyeingOpreation)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.MachineType)
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