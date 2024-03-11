using FluentValidation;
using Shopfloor.Production.Application.Command.DefectCapturing4Pointss;

namespace Shopfloor.Production.Application.Validations.DefectCapturing4Pointss
{
    public class UpdateDefectCapturing4PointsCommandValidator : AbstractValidator<UpdateDefectCapturing4PointsCommand>
    {
        public UpdateDefectCapturing4PointsCommandValidator()
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

            RuleFor(p => p.MinorOne)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");
            RuleFor(p => p.MinorTwo)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");
            RuleFor(p => p.MinorThree)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");
            RuleFor(p => p.MinorFour)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

            RuleFor(p => p.MajorOne)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

            RuleFor(p => p.MajorTwo)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

            RuleFor(p => p.MajorThree)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

            RuleFor(p => p.MajorFour)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

            RuleFor(p => p.DefectQtyOne)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");
            RuleFor(p => p.DefectQtyTwo)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");
            RuleFor(p => p.DefectQtyThree)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");
            RuleFor(p => p.DefectQtyFour)
                .GreaterThan(0).WithMessage("{PropertyName} must null or great than 0.");

        }
    }
}
