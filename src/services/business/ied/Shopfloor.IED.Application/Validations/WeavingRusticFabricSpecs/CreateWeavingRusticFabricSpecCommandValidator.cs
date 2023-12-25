using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingRusticFabricSpecs;

namespace Shopfloor.IED.Application.Validations.WeavingRusticFabricSpecs
{
    public class CreateWeavingRusticFabricSpecCommandValidator : AbstractValidator<CreateWeavingRusticFabricSpecCommand>
    {
        public CreateWeavingRusticFabricSpecCommandValidator()
        {
            RuleFor(p => p.BackgroundType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.BorderType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MachineType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }
    }
}
