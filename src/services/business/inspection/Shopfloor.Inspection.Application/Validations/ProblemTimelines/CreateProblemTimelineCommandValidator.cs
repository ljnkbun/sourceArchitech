using FluentValidation;
using Shopfloor.Inspection.Application.Command.ProblemTimelines;

namespace Shopfloor.Inspection.Application.Validations.ProblemTimelines
{
    public class CreateProblemTimelineCommandValidator : AbstractValidator<CreateProblemTimelineCommand>
    {
        public CreateProblemTimelineCommandValidator()
        {
            RuleFor(p => p.NameVN).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.NameEN).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.DivisonName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.ProcessName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.CategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.SubCategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.InspectionType).IsInEnum().WithMessage("Value is not part of the enum.");
        }
    }
}
