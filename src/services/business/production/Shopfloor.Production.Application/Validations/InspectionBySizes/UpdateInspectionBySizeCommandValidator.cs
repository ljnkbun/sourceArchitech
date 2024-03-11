using FluentValidation;
using Shopfloor.Production.Application.Command.InspectionBySizes;

namespace Shopfloor.Production.Application.Validations.InspectionBySizes
{
    public class UpdateInspectionBySizeCommandValidator : AbstractValidator<UpdateInspectionBySizeCommand>
    {
        public UpdateInspectionBySizeCommandValidator()
        {
            RuleFor(p => p.FPPOOutputDetailId).NotEmpty().NotNull().WithMessage("{PropertyName} must not be null.");
            RuleFor(p => p.ProductionOutputId).NotEmpty().NotNull().WithMessage("{PropertyName} must not be null.");
        }
    }
}
