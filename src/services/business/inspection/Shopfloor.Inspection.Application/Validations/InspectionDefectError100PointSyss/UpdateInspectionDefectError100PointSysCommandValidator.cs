using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectError100PointSyss
{
    public class UpdateInspectionDefectError100PointSysCommandValidator : AbstractValidator<UpdateInspectionDefectError100PointSysCommand>
    {
        public UpdateInspectionDefectError100PointSysCommandValidator()
        {
            RuleFor(r => r.InspectionDefectCapturing100PointSysId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.From).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }

    }
}
