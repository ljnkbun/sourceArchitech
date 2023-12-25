using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingDetailStructures;

namespace Shopfloor.IED.Application.Validations.WeavingDetailStructures
{
    public class UpdateWeavingDetailStructureCommandValidator : AbstractValidator<UpdateWeavingDetailStructureCommand>
    {
        public UpdateWeavingDetailStructureCommandValidator()
        {
            RuleFor(p => p.StructureType).IsInEnum();
        }
    }
}
