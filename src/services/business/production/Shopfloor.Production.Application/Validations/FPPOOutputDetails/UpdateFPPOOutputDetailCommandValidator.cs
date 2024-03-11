using FluentValidation;
using Shopfloor.Production.Application.Command.FPPOOutputDetails;

namespace Shopfloor.Production.Application.Validations.FPPOOutputDetails
{
    public class UpdateFPPOOutputDetailCommandValidator : AbstractValidator<UpdateFPPOOutputDetailCommand>
    {
        public UpdateFPPOOutputDetailCommandValidator()
        {
            RuleFor(p => p.FPPOOutputId)
                  .NotEmpty().WithMessage("{PropertyName} is required.")
                  .NotNull().WithMessage("{PropertyName} must not be null.");

            RuleFor(p => p.Size)
                 .NotEmpty().WithMessage("{PropertyName} is required.")
                 .NotNull()
                 .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Color)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        }
    }
}
