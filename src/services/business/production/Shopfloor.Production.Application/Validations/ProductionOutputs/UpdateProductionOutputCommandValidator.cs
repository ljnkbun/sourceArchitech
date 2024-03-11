using FluentValidation;
using Shopfloor.Production.Application.Command.ProductionOutputs;

namespace Shopfloor.Production.Application.Validations.ProductionOutputs
{
    public class UpdateProductionOutputCommandValidator : AbstractValidator<UpdateProductionOutputCommand>
    {
        public UpdateProductionOutputCommandValidator()
        {

            RuleFor(p => p.FPPOOutputId).NotEmpty().NotNull().WithMessage("{PropertyName} must not be null.");
            RuleFor(p => p.QCDefinitionId).NotEmpty().NotNull().WithMessage("{PropertyName} must not be null.");
            RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("{PropertyName} must not be null.");

            RuleFor(p => p.Status)
               .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.Code)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Remarks)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Status).IsInEnum().WithMessage("{PropertyName} must in Enum.");
            RuleFor(p => p.WFXExportStatus).IsInEnum().WithMessage("{PropertyName} must in Enum.");

        }
    }
}
