using FluentValidation;
using Shopfloor.Production.Application.Command.InspectionBySizes;

namespace Shopfloor.Production.Application.Validations.InspectionBySizes
{
    public class CreateInspectionBySizeCommandValidator : AbstractValidator<CreateInspectionBySizeCommand>
    {
        public CreateInspectionBySizeCommandValidator()
        {
           
            RuleFor(p => p.FPPOOutputDetailId).NotEmpty().NotNull().WithMessage("{PropertyName} must not be null.");

        }
    }
}
