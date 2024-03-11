using FluentValidation;
using Shopfloor.Inspection.Application.Command.Inspections;

namespace Shopfloor.Inspection.Application.Validations.Inspections
{
    public class CreateInspectionCommandValidator : AbstractValidator<CreateInspectionCommand>
    {
        public CreateInspectionCommandValidator()
        {
          
            RuleFor(p => p.Reason).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Line).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(r => r.TotalDefect).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.Stage).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.CuttingTable).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
    }
}
