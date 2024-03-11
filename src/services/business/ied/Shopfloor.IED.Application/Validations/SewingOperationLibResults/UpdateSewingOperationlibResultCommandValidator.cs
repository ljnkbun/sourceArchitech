using EnumsNET;
using FluentValidation;
using Shopfloor.IED.Application.Command.SewingOperationLibResults;

namespace Shopfloor.IED.Application.Validations.SewingOperationLibResults
{
    public class UpdateSewingOperationLibResultCommandValidator : AbstractValidator<UpdateSewingOperationLibResultCommand>
    {
        public UpdateSewingOperationLibResultCommandValidator()
        {
            RuleForEach(p => p.SewingOperationLibResultModels).Must(r => r.TMUType.IsDefined()).WithMessage("TMUType out of range.");
        }
    }
}
