using FluentValidation;
using Shopfloor.IED.Application.Query.RequestArticleOutputs;

namespace Shopfloor.IED.Application.Validations.RequestArticleOutputs
{
    public class GetRequestArticleOutputsQueryValidator : AbstractValidator<GetRequestArticleOutputsQuery>
    {
        public GetRequestArticleOutputsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
