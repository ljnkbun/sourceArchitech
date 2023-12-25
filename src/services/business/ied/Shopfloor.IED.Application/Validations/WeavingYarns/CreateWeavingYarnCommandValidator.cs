using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingYarns;

namespace Shopfloor.IED.Application.Validations.WeavingYarns
{
    public class CreateWeavingYarnCommandValidator : AbstractValidator<CreateWeavingYarnCommand>
    {
        public CreateWeavingYarnCommandValidator()
        {
            RuleFor(p => p.YarnCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.YarnName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }
    }
}
