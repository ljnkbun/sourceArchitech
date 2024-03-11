using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingSpecifications;

namespace Shopfloor.IED.Application.Validations.WeavingSpecifications
{
    public class CreateWeavingSpecificationCommandValidator : AbstractValidator<CreateWeavingSpecificationCommand>
    {
        public CreateWeavingSpecificationCommandValidator()
        {
            RuleFor(p => p.WeavingIEDId).NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.WeavingRusticFabricSpec)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.WeavingRusticFabricSpec.ContentWeaveStyle)
                .NotEmpty().When(x => x.WeavingRusticFabricSpec != null).WithMessage("{PropertyName} is required.")
                .NotNull().When(x => x.WeavingRusticFabricSpec != null)
                .MaximumLength(50).When(x => x.WeavingRusticFabricSpec != null).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.WeavingRusticFabricSpec.MarginWeaveStyle)
                .NotEmpty().When(x => x.WeavingRusticFabricSpec != null).WithMessage("{PropertyName} is required.")
                .NotNull().When(x => x.WeavingRusticFabricSpec != null)
                .MaximumLength(50).When(x => x.WeavingRusticFabricSpec != null).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.WeavingRusticFabricSpec.MachineType)
                .NotEmpty().When(x => x.WeavingRusticFabricSpec != null).WithMessage("{PropertyName} is required.")
                .NotNull().When(x => x.WeavingRusticFabricSpec != null)
                .MaximumLength(250).When(x => x.WeavingRusticFabricSpec != null).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleForEach(p => p.WeavingDetailStructures).ChildRules(childWeavingDetailStructures =>
            {
                childWeavingDetailStructures.RuleFor(p => p.StructureType).IsInEnum();

                childWeavingDetailStructures.RuleFor(p => p.WeavingIEDId)
                    .NotEmpty().WithMessage("{PropertyName} is required.");
            });

            RuleForEach(p => p.WeavingYarns).ChildRules(childWeavingYarns =>
            {
                childWeavingYarns.RuleFor(p => p.WeavingIEDId)
                    .NotEmpty().WithMessage("{PropertyName} is required.");

                childWeavingYarns.RuleFor(p => p.YarnCode)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childWeavingYarns.RuleFor(p => p.YarnName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childWeavingYarns.RuleFor(p => p.WFXYarnId)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
            });
        }
    }
}