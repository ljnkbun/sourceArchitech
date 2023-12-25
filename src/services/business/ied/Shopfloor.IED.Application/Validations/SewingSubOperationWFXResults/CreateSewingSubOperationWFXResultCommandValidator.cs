using EnumsNET;
using FluentValidation;
using Shopfloor.IED.Application.Command.SewingSubOperationWFXResults;

namespace Shopfloor.IED.Application.Validations.SewingSubOperationWFXResults
{
    public class CreateSewingSubOperationWFXResultCommandValidator : AbstractValidator<CreateSewingSubOperationWFXResultCommand>
    {
        public CreateSewingSubOperationWFXResultCommandValidator()
        {
            RuleForEach(p => p.SewingSubOperationWFXResultModels).Must(r => r.TMUType.IsDefined()).WithMessage("TMUType out of range.");
        }
    }
}
