using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturingTCStandards;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectCapturingTCStandards
{
    public class UpdateInspectionDefectCapturingTCStandardCommandValidator : AbstractValidator<UpdateInspectionDefectCapturingTCStandardCommand>
    {
        public UpdateInspectionDefectCapturingTCStandardCommandValidator()
        {
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }

    }
}
