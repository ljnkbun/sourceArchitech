using FluentValidation;
using Shopfloor.Barcode.Application.Command.Imports;

namespace Shopfloor.Barcode.Application.Validations.Imports
{
    public class UpdateStatusImportCommandValidator : AbstractValidator<UpdateImportStatusCommand>
    {
        public UpdateStatusImportCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");
            RuleFor(p=>p.Status).IsInEnum().WithMessage("Value is not part of the enum.");
        }
        
    }
}
