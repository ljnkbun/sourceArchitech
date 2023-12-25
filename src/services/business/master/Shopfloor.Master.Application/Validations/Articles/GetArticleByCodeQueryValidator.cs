using FluentValidation;
using Shopfloor.Master.Application.Query.Articles;

namespace Shopfloor.Master.Application.Validations.Articles
{
    public class GetArticleByCodeQueryValidator : AbstractValidator<GetArticleByCodeQuery>
    {
        public GetArticleByCodeQueryValidator()
        {
            RuleFor(p => p.Code)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}