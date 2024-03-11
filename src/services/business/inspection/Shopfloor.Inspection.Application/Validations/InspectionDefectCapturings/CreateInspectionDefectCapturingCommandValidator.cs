using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionDefectCapturings;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectCapturings
{
    public class CreateInspectionDefectCapturingCommandValidator : AbstractValidator<CreateInspectionDefectCapturingCommand>
    {
        public CreateInspectionDefectCapturingCommandValidator()
        {
            RuleFor(r => r.QCDefectId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
    }
}
