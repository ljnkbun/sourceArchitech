using FluentValidation;
using Shopfloor.IED.Application.Command.SewingRoutings;

namespace Shopfloor.IED.Application.Validations.SewingRoutings
{
    public class UpdateSewingRoutingsCommandValidator : AbstractValidator<UpdateSewingRoutingsCommand>
    {
        public UpdateSewingRoutingsCommandValidator()
        {
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");

            RuleForEach(x => x.SewingRoutings).ChildRules(child =>
            {
                child.RuleFor(p => p.WFXProcessCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                child.RuleFor(p => p.WFXProcessName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.WFXOperationCode)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                child.RuleFor(p => p.WFXOperationName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            });
        }
        private bool IsLineNumberUnique(UpdateSewingRoutingsCommand command)
        {
            return command?.SewingRoutings.DistinctBy(m => m.LineNumber).Count() == command?.SewingRoutings.Count;
        }
    }
}
