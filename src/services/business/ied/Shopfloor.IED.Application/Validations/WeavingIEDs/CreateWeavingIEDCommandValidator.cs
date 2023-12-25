using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingIEDs;

namespace Shopfloor.IED.Application.Validations.WeavingIEDs
{
    public class CreateWeavingIEDCommandValidator : AbstractValidator<CreateWeavingIEDCommand>
    {
        public CreateWeavingIEDCommandValidator()
        {
            RuleFor(p => p.RequestNo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Comment)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }
    }
}
