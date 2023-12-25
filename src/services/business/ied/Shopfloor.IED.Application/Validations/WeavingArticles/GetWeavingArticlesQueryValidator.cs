using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingArticles;

namespace Shopfloor.IED.Application.Validations.WeavingArticles
{
    public class GetWeavingArticlesQueryValidator : AbstractValidator<GetWeavingArticlesQuery>
    {
        public GetWeavingArticlesQueryValidator()
        {
            RuleFor(p => p.ArticleCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
