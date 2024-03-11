using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactories;

namespace Shopfloor.Planning.Application.Validations.StripFactories
{
    public class UpdateStripFactoryCommandValidator : AbstractValidator<UpdateStripFactoryCommand>
    {
        public UpdateStripFactoryCommandValidator()
        {
            RuleFor(r => r.PlanningGroupFactoryId)
                .GreaterThan(0).WithMessage("{PropertyName}  is required.");

            RuleFor(r => r.PORId)
                .GreaterThan(0).WithMessage("{PropertyName}  is required.");

            RuleFor(r => r.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
    }
}
