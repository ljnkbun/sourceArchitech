using FluentValidation;
using Shopfloor.Master.Application.Query.PlanningGroupFactories;

namespace Shopfloor.Master.Application.Validations.PlanningGroupFactories
{
    public class GetPlanningGroupFactoriesQueryValidator : AbstractValidator<GetPlanningGroupFactoriesQuery>
    {
        public GetPlanningGroupFactoriesQueryValidator()
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
