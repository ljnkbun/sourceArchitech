using FluentValidation;
using Shopfloor.Planning.Application.Command.CapacityColors;

namespace Shopfloor.Planning.Application.Validations.CapacityColors
{
    public class UpdateCapacityColorCommandValidator : AbstractValidator<UpdateCapacityColorCommand>
    {
        public UpdateCapacityColorCommandValidator()
        {
            RuleFor(p => p.Color).NotEmpty().WithMessage("{PropertyName}  is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(r => r.FromRange).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToRange).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToRange).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToRange).GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }

    }
}
