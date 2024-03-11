using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingYarns;

namespace Shopfloor.IED.Application.Validations.KnittingYarns
{
    public class UpdateKnittingYarnsCommandValidator : AbstractValidator<UpdateKnittingYarnsCommand>
    {
        public UpdateKnittingYarnsCommandValidator()
        {
            RuleForEach(x => x.KnittingYarnModels).ChildRules(child =>
            {
                child.RuleFor(p => p.YarnCode)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.YarnName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.Color)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
                child.RuleFor(p => p).Must(p => p.YarnRatio >= 0).WithMessage("YarnRatio must greater than or equal 0.");
                child.RuleFor(p => p).Must(p => p.Weight >= 0).WithMessage("Weight must greater than or equal 0.");
                child.RuleFor(p => p).Must(p => p.Wastage >= 0).WithMessage("Wastage must greater than or equal 0.");
            });
        }
    }
}
