using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingSpecifications;

namespace Shopfloor.IED.Application.Validations.WeavingSpecifications
{
    public class CreateWeavingRappoSpecificationCommandValidator : AbstractValidator<CreateWeavingRappoSpecificationCommand>
    {
        public CreateWeavingRappoSpecificationCommandValidator()
        {
            RuleFor(p => p.WeavingIEDId).NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.WeavingRappo)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(e => e.WeavingRappo.Line).Must(e => e >= 1).When(x => x.WeavingRappo != null).WithMessage("Line must greater than or equal 1.");

            RuleFor(e => e.WeavingRappo.WarpPerMarginDentSplit).Must(e => e >= 1).When(x => x.WeavingRappo != null).WithMessage("WarpPerMarginDentSplit must greater than or equal 1.");

            RuleFor(e => e.WeavingRappo.WarpPerContentDentSplit).Must(e => e >= 1).When(x => x.WeavingRappo != null).WithMessage("WarpPerContentDentSplit must greater than or equal 1.");

            RuleFor(e => e.WeavingRappo.TotalRappo).Must(e => e >= 1).When(x => x.WeavingRappo != null).WithMessage("TotalRappo must greater than or equal 1.");

            RuleFor(e => e.WeavingRappo.AdditionYarn).Must(e => e >= 0).When(x => x.WeavingRappo != null).WithMessage("AdditionYarn must greater than or equal 0.");

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