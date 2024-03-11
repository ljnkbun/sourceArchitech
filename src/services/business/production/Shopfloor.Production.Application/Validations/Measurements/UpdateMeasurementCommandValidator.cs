using FluentValidation;
using Shopfloor.Production.Application.Command.Measurements;

namespace Shopfloor.Production.Application.Validations.Measurements
{
    public class UpdateMeasurementCommandValidator : AbstractValidator<UpdateMeasurementCommand>
    {
        public UpdateMeasurementCommandValidator()
        {
            RuleFor(p => p.ProductionOutputId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.ErrorCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ErrorName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Minor)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

            RuleFor(p => p.Major)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

            RuleFor(p => p.Critical)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

        }
    }
}
