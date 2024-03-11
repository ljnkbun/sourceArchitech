using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionDefectError4PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectError4PointSyss
{
    public class UpdateInspectionDefectError4PointSysCommandValidator : AbstractValidator<UpdateInspectionDefectError4PointSysCommand>
    {
        public UpdateInspectionDefectError4PointSysCommandValidator()
        {
            RuleFor(r => r.InspectionDefectCapturing4PointSysId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.From).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }

    }
}
