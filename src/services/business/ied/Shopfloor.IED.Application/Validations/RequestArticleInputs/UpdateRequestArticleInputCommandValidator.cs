using FluentValidation;
using Shopfloor.IED.Application.Command.RequestArticleInputs;

namespace Shopfloor.IED.Application.Validations.RequestArticleInputs
{
    public class UpdateRequestArticleInputCommandValidator : AbstractValidator<UpdateRequestArticleInputCommand>
    {
        public UpdateRequestArticleInputCommandValidator()
        {
            RuleFor(p => p.ArticleCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
