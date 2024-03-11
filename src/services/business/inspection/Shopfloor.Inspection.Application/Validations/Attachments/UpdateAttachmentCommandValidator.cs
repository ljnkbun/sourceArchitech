using FluentValidation;
using Shopfloor.Inspection.Application.Command.Attachments;

namespace Shopfloor.Inspection.Application.Validations.Attachments
{
    public class UpdateAttachmentCommandValidator : AbstractValidator<UpdateAttachmentCommand>
    {
        public UpdateAttachmentCommandValidator()
        {
            RuleFor(r => r.InspectionId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.FileName).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Description).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.FileId).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        }

    }
}
