using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingRappos;

namespace Shopfloor.IED.Application.Validations.WeavingRappos
{
    public class UpdateWeavingRappoCommandValidator : AbstractValidator<UpdateWeavingRappoCommand>
    {
        public UpdateWeavingRappoCommandValidator()
        {
            RuleFor(e => e.Line).Must(e => e >= 1).WithMessage("Line must greater than or equal 1.");
            RuleFor(e => e.WarpPerMarginDentSplit).Must(e => e >= 1).WithMessage("WarpPerMarginDentSplit must greater than or equal 1.");
            RuleFor(e => e.WarpPerContentDentSplit).Must(e => e >= 1).WithMessage("WarpPerContentDentSplit must greater than or equal 1.");
            RuleFor(e => e.TotalRappo).Must(e => e >= 1).WithMessage("TotalRappo must greater than or equal 1.");
            RuleFor(e => e.AdditionYarn).Must(e => e >= 0).WithMessage("AdditionYarn must greater than or equal 0.");
        }
    }
}
