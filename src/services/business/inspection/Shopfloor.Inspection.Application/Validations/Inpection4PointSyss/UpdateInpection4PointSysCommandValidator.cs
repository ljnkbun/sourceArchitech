using FluentValidation;
using Shopfloor.Inspection.Application.Command.Inpection4PointSyss;

namespace Shopfloor.Inspection.Application.Validations.Inpection4PointSyss
{
    public class UpdateInpection4PointSysCommandValidator : AbstractValidator<UpdateInpection4PointSysCommand>
    {
        public UpdateInpection4PointSysCommandValidator()
        {
            RuleFor(p => p.StockMovementNo).MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");
            RuleFor(r => r.CaptureMeter).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ActualWeight).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Grade).MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

        }

    }
}
