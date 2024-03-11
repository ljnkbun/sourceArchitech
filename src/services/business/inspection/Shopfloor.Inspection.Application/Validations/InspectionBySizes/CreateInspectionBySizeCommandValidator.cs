using FluentValidation;
using Shopfloor.Inspection.Application.Command.InspectionBySizes;

namespace Shopfloor.Inspection.Application.Validations.InspectionBySizes
{
    public class CreateInspectionBySizeCommandValidator : AbstractValidator<CreateInspectionBySizeCommand>
    {
        public CreateInspectionBySizeCommandValidator()
        {
            RuleFor(p => p.ColorCode).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.ColorName).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.SizeCode).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.SizeName).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Shade).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.Lot).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
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
