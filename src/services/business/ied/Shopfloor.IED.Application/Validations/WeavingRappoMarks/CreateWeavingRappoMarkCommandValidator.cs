using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingRappoMarks;

namespace Shopfloor.IED.Application.Validations.WeavingRappoMarks
{
    public class CreateWeavingRappoMarkCommandValidator : AbstractValidator<CreateWeavingRappoMarkCommand>
    {
        public CreateWeavingRappoMarkCommandValidator()
        {
            RuleFor(p => p.ColumnNo)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.PatternIndex)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
