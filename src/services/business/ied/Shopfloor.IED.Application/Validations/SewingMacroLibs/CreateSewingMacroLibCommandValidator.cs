using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMacroLibs;
using Shopfloor.IED.Domain.Enums;

namespace Shopfloor.IED.Application.Validations.SewingMacroLibs
{
    public class CreateSewingMacroLibCommandValidator : AbstractValidator<CreateSewingMacroLibCommand>
    {
        public CreateSewingMacroLibCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleFor(p => p).Must(IsValid).WithMessage("Data invalid.");

            RuleForEach(x => x.SewingMacroLibBOLs).ChildRules(child =>
            {
                child.RuleFor(p => p.Code).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                child.RuleFor(p => p.Name).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
                child.RuleFor(p => p.Freq).MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                child.RuleFor(p => p.Type).IsInEnum().WithMessage("Type out of range.");
                child.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            });
        }
        private bool IsLineNumberUnique(CreateSewingMacroLibCommand command)
        {
            return command?.SewingMacroLibBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingMacroLibBOLs.Count;
        }
        private bool IsValid(CreateSewingMacroLibCommand command)
        {
            return command?.SewingMacroLibBOLs.All(b => (b.Type == MacroBOLType.CM && b.SewingTaskLibId == null)
                                                         || (b.Type != MacroBOLType.CM && b.SewingTaskLibId != null)) ?? true;
        }
    }
}
