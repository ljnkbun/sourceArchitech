using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturing100PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectCapturing100PointSyss
{
    public class UpdateInspectionDefectCapturing100PointSysCommandValidator : AbstractValidator<UpdateInspectionDefectCapturing100PointSysCommand>
    {
        public UpdateInspectionDefectCapturing100PointSysCommandValidator()
        {
            RuleFor(r => r.Inpection100PointSysId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.QCDefectId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

    }
}
