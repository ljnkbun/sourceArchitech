using FluentValidation;
using Shopfloor.IED.Application.Command.SewingRoutings;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Validations.SewingRoutings
{
    public class CreateSewingRoutingCommandValidator : AbstractValidator<CreateSewingRoutingCommand>
    {
        public CreateSewingRoutingCommandValidator()
        {
            RuleFor(p => p.WFXProcessCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.WFXProcessName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.WFXOperationCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.WFXOperationName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleFor(p => p).Must(IsValid).WithMessage("Data invalid.");

            RuleForEach(x => x.SewingRoutingBOLs).ChildRules(child =>
            {
                child.RuleFor(p => p.Code).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                child.RuleFor(p => p.Name).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
                child.RuleFor(p => p.Freq).MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                child.RuleFor(p => p.Type).IsInEnum().WithMessage("Type out of range.");
                child.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            });
        }
        private bool IsValid(CreateSewingRoutingCommand command)
        {
            return command?.SewingRoutingBOLs.All(b => (b.Type == SewingRoutingType.OP && b.SewingOperationLibId != null)
                                                         || (b.Type == SewingRoutingType.FT && b.SewingFeatureLibId != null)) ?? true;
        }
        private bool IsLineNumberUnique(CreateSewingRoutingCommand command)
        {
            return command?.SewingRoutingBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingRoutingBOLs.Count;
        }
    }
}
