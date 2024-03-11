using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing4PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectCapturing4PointSyss
{
    public class CreateInspectionDefectCapturing4PointSysCommandValidator : AbstractValidator<CreateInspectionDefectCapturing4PointSysCommand>
    {
        public CreateInspectionDefectCapturing4PointSysCommandValidator()
        {
            RuleFor(r => r.Inpection4PointSysId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.QCDefectId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
