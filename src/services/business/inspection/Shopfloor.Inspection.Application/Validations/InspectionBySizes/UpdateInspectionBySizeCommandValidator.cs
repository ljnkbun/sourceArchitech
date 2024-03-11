using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionBySizes;

namespace Shopfloor.Inspection.Application.Validations.InspectionBySizes
{
    public class UpdateInspectionBySizeCommandValidator : AbstractValidator<UpdateInspectionBySizeCommand>
    {
        public UpdateInspectionBySizeCommandValidator()
        {
           
            RuleFor(r => r.GRNQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.PreInspectedQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.LotQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.InspectionQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ActualQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.NoOfDefect).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.OKQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.BGroupQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.BGroupUsable).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.RejectedQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ExcessShortageQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.ReasonforBGroup).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

    }
}
