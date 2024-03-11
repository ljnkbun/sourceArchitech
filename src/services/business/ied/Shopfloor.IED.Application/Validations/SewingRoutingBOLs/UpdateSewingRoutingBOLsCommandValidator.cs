using FluentValidation;
using Shopfloor.IED.Application.Command.SewingRoutingBOLs;

namespace Shopfloor.IED.Application.Validations.SewingRoutingBOLs
{
    public class UpdateSewingRoutingBOLsCommandValidator : AbstractValidator<UpdateSewingRoutingBOLsCommand>
    {
        public UpdateSewingRoutingBOLsCommandValidator()
        {
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleForEach(x => x.SewingRoutingBOLs).ChildRules(child =>
            {
                child.RuleFor(p => p.Code).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                child.RuleFor(p => p.Name).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
                child.RuleFor(p => p.Freq).MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                child.RuleFor(p => p.Type).IsInEnum().WithMessage("Type out of range.");
                child.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            });
        }
        private bool IsLineNumberUnique(UpdateSewingRoutingBOLsCommand command)
        {
            return command?.SewingRoutingBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingRoutingBOLs.Count;
        }
    }
}
