using FluentValidation;
using Shopfloor.Production.Application.Command.DefectCapturing100Pointss;

namespace Shopfloor.Production.Application.Validations.DefectCapturing100Pointss
{
    public class UpdateDefectCapturing100PointsCommandValidator : AbstractValidator<UpdateDefectCapturing100PointsCommand>
    {
        public UpdateDefectCapturing100PointsCommandValidator()
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

            RuleFor(p => p.Critial)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");


        }
    }
}
