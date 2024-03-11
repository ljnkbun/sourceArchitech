using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionMesurements;

namespace Shopfloor.Inspection.Application.Validations.InspectionMesurements
{
    public class UpdateInspectionMesurementCommandValidator : AbstractValidator<UpdateInspectionMesurementCommand>
    {
        public UpdateInspectionMesurementCommandValidator()
        {
            RuleFor(r => r.QCDefectId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }

    }
}
