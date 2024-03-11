using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionMesurements;

namespace Shopfloor.Inspection.Application.Validations.InspectionMesurements
{
    public class CreateInspectionMesurementCommandValidator : AbstractValidator<CreateInspectionMesurementCommand>
    {
        public CreateInspectionMesurementCommandValidator()
        {
            RuleFor(r => r.QCDefectId).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
    }
}
