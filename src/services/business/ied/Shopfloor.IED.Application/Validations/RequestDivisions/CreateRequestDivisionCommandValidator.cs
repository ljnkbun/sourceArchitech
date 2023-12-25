using FluentValidation;
using Shopfloor.IED.Application.Command.RequestDivisions;

namespace Shopfloor.IED.Application.Validations.RequestDivisions
{
    public class CreateRequestDivisionCommandValidator : AbstractValidator<CreateRequestDivisionCommand>
    {
        public CreateRequestDivisionCommandValidator()
        {
            RuleFor(p => p.DivisionCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.DivisionName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
    }
}
