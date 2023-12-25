using FluentValidation;
using Shopfloor.IED.Application.Command.RequestDivisions;

namespace Shopfloor.IED.Application.Validations.RequestDivisions
{
    public class UpdateRequestDivisionCommandValidator : AbstractValidator<UpdateRequestDivisionCommand>
    {
        public UpdateRequestDivisionCommandValidator()
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
