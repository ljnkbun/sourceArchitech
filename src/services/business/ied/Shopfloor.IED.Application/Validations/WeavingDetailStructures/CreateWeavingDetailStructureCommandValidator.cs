using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingDetailStructures;

namespace Shopfloor.IED.Application.Validations.WeavingDetailStructures
{
    public class CreateWeavingDetailStructureCommandValidator : AbstractValidator<CreateWeavingDetailStructureCommand>
    {
        public CreateWeavingDetailStructureCommandValidator()
        {
            RuleFor(p => p.StructureType).IsInEnum();
        }
    }
}
