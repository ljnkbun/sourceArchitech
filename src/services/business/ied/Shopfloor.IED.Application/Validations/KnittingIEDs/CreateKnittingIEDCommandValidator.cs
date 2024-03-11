using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingIEDs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingIEDs
{
    public class CreateKnittingIEDCommandValidator : AbstractValidator<CreateKnittingIEDCommand>
    {
        public CreateKnittingIEDCommandValidator()
        {
            RuleFor(p => p.ArticleCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ArticleName)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ProductGroup)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategory)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
               .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Status).IsInEnum().WithMessage("{PropertyName} out of range.");
        }
    }
}
