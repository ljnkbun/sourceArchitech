using FluentValidation;
using Shopfloor.Master.Application.Command.Processes;

namespace Shopfloor.Master.Application.Validations.Processs
{
    public class CreateProcessCommandValidator : AbstractValidator<CreateProcessCommand>
    {
        public CreateProcessCommandValidator()
        {

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
