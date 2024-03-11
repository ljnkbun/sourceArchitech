using FluentValidation;
using Shopfloor.Barcode.Application.Query.WfxPOArticles;

namespace Shopfloor.Barcode.Application.Validations.WfxPOArticles
{
    public class GetWfxPOArticlesQueryValidator : AbstractValidator<GetWfxPOArticlesQuery>
    {
        public GetWfxPOArticlesQueryValidator()
        {
            RuleFor(p => p.ArticleCode)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.SupplierName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.OrderRefNum)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ToOrderDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.OrderType)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.ArticleType)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

        }
    }
}
