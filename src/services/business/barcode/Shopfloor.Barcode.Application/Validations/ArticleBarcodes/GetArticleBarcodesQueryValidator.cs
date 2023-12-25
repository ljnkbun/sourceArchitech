using FluentValidation;
using Shopfloor.Barcode.Application.Query.ArticleBarcodes;

namespace Shopfloor.Barcode.Application.Validations.ArticleBarcodes
{
    public class GetArticleBarcodesQueryValidator : AbstractValidator<GetArticleBarcodesQuery>
    {
        public GetArticleBarcodesQueryValidator()
        {
            RuleFor(p => p.Barcode)
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
