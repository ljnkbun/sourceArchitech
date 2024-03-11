using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingIEDs;

namespace Shopfloor.IED.Application.Validations.WeavingIEDs
{
    public class UpdateWeavingIEDCommandValidator : AbstractValidator<UpdateWeavingIEDCommand>
    {
        public UpdateWeavingIEDCommandValidator()
        {
            RuleFor(p => p.ArticleCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ProductGroup)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategory)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }
    }
}
