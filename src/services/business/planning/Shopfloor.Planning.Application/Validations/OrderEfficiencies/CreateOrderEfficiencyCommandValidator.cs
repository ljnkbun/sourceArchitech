using FluentValidation;
using Shopfloor.Planning.Application.Command.OrderEfficiencies;

namespace Shopfloor.Planning.Application.Validations.OrderEfficiencies
{
    public class CreateOrderEfficiencyCommandValidator : AbstractValidator<CreateOrderEfficiencyCommand>
    {
        public CreateOrderEfficiencyCommandValidator()
        {
            RuleFor(p => p.OCNo)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.EfficiencyValue)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }
    }
}
