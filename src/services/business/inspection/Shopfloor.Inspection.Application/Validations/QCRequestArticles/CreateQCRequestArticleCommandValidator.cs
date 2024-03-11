using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCRequestArticles;

namespace Shopfloor.Inspection.Application.Validations.QCRequestArticles
{
    public class CreateQCRequestArticleCommandValidator : AbstractValidator<CreateQCRequestArticleCommand>
    {
        public CreateQCRequestArticleCommandValidator()
        {
            RuleFor(r => r.QCRequestId).GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(p => p.ArticleCode).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.ArticleName).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Shade).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.Lot).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.StyleNo).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.StyleName).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.Season).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.Buyer).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.FPONo).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.Location).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.UOM).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.OCNo).MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.GRNNo).MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.PONo).MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(r => r.RequestedQty).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
    }
}
