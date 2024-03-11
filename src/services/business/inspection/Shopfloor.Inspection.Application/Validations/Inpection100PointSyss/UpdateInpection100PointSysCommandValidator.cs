using FluentValidation;
using Shopfloor.Inspection.Application.Command.Inpection100PointSyss;

namespace Shopfloor.Inspection.Application.Validations.Inpection100PointSyss
{
    public class UpdateInpection100PointSysCommandValidator : AbstractValidator<UpdateInpection100PointSysCommand>
    {
        public UpdateInpection100PointSysCommandValidator()
        {
            RuleFor(p => p.StockMovementNo).MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
            RuleFor(r => r.CaptureMeter).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ActualWeight).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Grade).MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

        }

    }
}
