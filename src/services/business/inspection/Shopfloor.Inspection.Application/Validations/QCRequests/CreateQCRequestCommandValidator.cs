using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCRequests;

namespace Shopfloor.Inspection.Application.Validations.QCRequests
{
    public class CreateQCRequestCommandValidator : AbstractValidator<CreateQCRequestCommand>
    {
        public CreateQCRequestCommandValidator()
        {
            RuleFor(p => p.SiteCode).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.SiteName).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.SupplierName).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.QCRequestNo).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.Category).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.DocumentNo).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.QCDefinitionCode).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(r => r.RequestedQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
    }
}
