using FluentValidation;
using Shopfloor.Ambassador.Application.Command.TestEntities;

namespace Shopfloor.Ambassador.Application.Validations.TestEntities
{
    public class CreateTestEntityCommandValidator : AbstractValidator<CreateTestEntityCommand>
    {
        public CreateTestEntityCommandValidator()
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
