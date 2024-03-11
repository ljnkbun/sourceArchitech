using FluentValidation;
using Shopfloor.Inspection.Application.Command.InpectionTCStandards;

namespace Shopfloor.Inspection.Application.Validations.InpectionTCStandards
{
    public class CreateInpectionTCStandardCommandValidator : AbstractValidator<CreateInpectionTCStandardCommand>
    {
        public CreateInpectionTCStandardCommandValidator()
        {
            RuleFor(p => p.StockMovementNo).MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
            RuleFor(p => p.Grade).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
