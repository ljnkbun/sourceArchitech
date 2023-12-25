using FluentValidation;
using Shopfloor.IED.Application.Command.RequestDivisionProcesses;

namespace Shopfloor.IED.Application.Validations.RequestDivisionProcesses
{
    public class CreateRequestDivisionProcessCommandValidator : AbstractValidator<CreateRequestDivisionProcessCommand>
    {
        public CreateRequestDivisionProcessCommandValidator()
        {
            RuleFor(p => p.ProcessCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ProcessName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Status).IsInEnum();
        }
    }
}
