using FluentValidation;
using Shopfloor.IED.Application.Query.SewingOperationWFXs;

namespace Shopfloor.IED.Application.Validations.SewingOperationWFXs
{
    public class GetSewingOperationWFXsQueryValidator : AbstractValidator<GetSewingOperationWFXsQuery>
    {
        public GetSewingOperationWFXsQueryValidator()
        {
            RuleFor(p => p.WFXProcessCode)
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.WFXProcessName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ProductGroup)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ProductSubCategory)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ArticleCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
