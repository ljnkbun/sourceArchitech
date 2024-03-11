using EnumsNET;
using FluentValidation;
using Shopfloor.IED.Application.Command.SewingOperationLibResults;

namespace Shopfloor.IED.Application.Validations.SewingOperationLibResults
{
    public class CreateSewingOperationLibResultCommandValidator : AbstractValidator<CreateSewingOperationLibResultCommand>
    {
        public CreateSewingOperationLibResultCommandValidator()
        {
            RuleForEach(p => p.SewingOperationLibResults).Must(r => r.Type.IsDefined()).WithMessage("TMUType out of range.");
        }
    }
}
