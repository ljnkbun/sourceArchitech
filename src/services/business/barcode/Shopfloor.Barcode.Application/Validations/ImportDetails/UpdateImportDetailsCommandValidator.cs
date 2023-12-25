using FluentValidation;
using Shopfloor.Barcode.Application.Command.ImportDetails;

namespace Shopfloor.Barcode.Application.Validations.ImportDetails
{
    public class UpdateImportDetailsCommandValidator : AbstractValidator<UpdateImportDetailsCommand>
    {
        public UpdateImportDetailsCommandValidator()
        {
            RuleForEach(item => item.updateImportDetailCommands).SetValidator(new UpdateImportDetailCommandValidator());
        }
    }
}
