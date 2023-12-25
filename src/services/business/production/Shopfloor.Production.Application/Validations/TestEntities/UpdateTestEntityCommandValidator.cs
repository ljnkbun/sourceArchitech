using FluentValidation;
using Shopfloor.Production.Application.Command.TestEntities;

namespace Shopfloor.Production.Application.Validations.TestEntities
{
    public class UpdateTestEntityCommandValidator : AbstractValidator<UpdateTestEntityCommand>
    {
        public UpdateTestEntityCommandValidator()
        {
            RuleFor(p => p.Property01)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Property02)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Type)
                .IsInEnum().WithMessage("Value is not part of the enum.");
        }
    }
}
