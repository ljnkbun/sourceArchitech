using FluentValidation;
using Shopfloor.Master.Application.Command.PlanningGroupFactories;

namespace Shopfloor.Master.Application.Validations.PlanningGroupFactories
{
    public class UpdatePlanningGroupFactoryCommandValidator : AbstractValidator<UpdatePlanningGroupFactoryCommand>
    {
        public UpdatePlanningGroupFactoryCommandValidator()
        {
            RuleFor(p => p.PlanningGroupId)
                .GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.FactoryId)
                .GreaterThan(0).WithMessage("{PropertyName} is required.");
        }
    }
}
