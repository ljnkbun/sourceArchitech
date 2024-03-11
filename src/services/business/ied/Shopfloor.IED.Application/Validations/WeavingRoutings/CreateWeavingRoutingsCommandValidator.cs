using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingRoutings;

namespace Shopfloor.IED.Application.Validations.WeavingRoutings
{
    public class CreateWeavingRoutingsCommandValidator : AbstractValidator<CreateWeavingRoutingsCommand>
    {
        public CreateWeavingRoutingsCommandValidator()
        {
            RuleForEach(x => x.WeavingRoutings).ChildRules(child =>
            {
                child.RuleFor(p => p.WeavingProcess)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.WeavingProcessCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            });
        }
    }
}