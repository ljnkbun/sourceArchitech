using FluentValidation;
using Shopfloor.Planning.Application.Command.StripFactories;

namespace Shopfloor.Planning.Application.Validations.StripFactories
{
    public class CreateStripFactoryCommandValidator : AbstractValidator<CreateStripFactoryCommand>
    {
        public CreateStripFactoryCommandValidator()
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
