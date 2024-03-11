using FluentValidation;
using Shopfloor.Production.Application.Command.DefectCapturingStandards;

namespace Shopfloor.Production.Application.Validations.DefectCapturingStandards
{
    public class UpdateDefectCapturingStandardCommandValidator : AbstractValidator<UpdateDefectCapturingStandardCommand>
    {
        public UpdateDefectCapturingStandardCommandValidator()
        {
            RuleFor(p => p.ProductionOutputId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.QCDefectId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Remark)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
    }
}
