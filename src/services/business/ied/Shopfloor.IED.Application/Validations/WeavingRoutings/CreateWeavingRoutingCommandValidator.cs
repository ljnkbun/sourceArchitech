using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingRoutings;

namespace Shopfloor.IED.Application.Validations.WeavingRoutings
{
    public class CreateWeavingRoutingCommandValidator : AbstractValidator<CreateWeavingRoutingCommand>
    {
        public CreateWeavingRoutingCommandValidator()
        {
            RuleFor(p => p.WeavingProcess)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.WeavingOperation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.MachineType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
    }
}
