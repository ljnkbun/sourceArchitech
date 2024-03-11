using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionDefectError100PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectError100PointSyss
{
    public class CreateInspectionDefectError100PointSysCommandValidator : AbstractValidator<CreateInspectionDefectError100PointSysCommand>
    {
        public CreateInspectionDefectError100PointSysCommandValidator()
        {
            RuleFor(r => r.InspectionDefectCapturing4PointSysId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.From).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
    }
}
