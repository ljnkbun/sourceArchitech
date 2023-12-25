using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingArticles;

namespace Shopfloor.IED.Application.Validations.WeavingArticles
{
    public class CreateWeavingArticleCommandValidator : AbstractValidator<CreateWeavingArticleCommand>
    {
        public CreateWeavingArticleCommandValidator()
        {
            RuleFor(p => p.ArticleCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }
    }
}
