using FluentValidation;
using Shopfloor.IED.Application.Command.RequestArticleOutputs;

namespace Shopfloor.IED.Application.Validations.RequestArticleOutputs
{
    public class UpdateRequestArticleOutputCommandValidator : AbstractValidator<UpdateRequestArticleOutputCommand>
    {
        public UpdateRequestArticleOutputCommandValidator()
        {
            RuleFor(p => p.ArticleCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Color)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
    }
}
