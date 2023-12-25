using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingRappos;

namespace Shopfloor.IED.Application.Validations.WeavingRappos
{
    public class UpdateWeavingRappoCommandValidator : AbstractValidator<UpdateWeavingRappoCommand>
    {
        public UpdateWeavingRappoCommandValidator()
        {
            RuleFor(e => e.NumOfLine).Must(e => e >= 1).WithMessage("NumOfLine must greater than or equal 1.");
            RuleFor(e => e.YarnOfBorder).Must(e => e >= 1).WithMessage("YarnOfBorder must greater than or equal 1.");
            RuleFor(e => e.YarnOfBackground).Must(e => e >= 1).WithMessage("YarnOfBackground must greater than or equal 1.");
            RuleFor(e => e.NumOfRappo).Must(e => e >= 1).WithMessage("NumOfRappo must greater than or equal 1.");
        }
    }
}
