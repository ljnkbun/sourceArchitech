using FluentValidation;
using Shopfloor.Barcode.Application.Query.ExportArticles;

namespace Shopfloor.Barcode.Application.Validations.ExportArticles
{
    public class GetExportArticlesQueryValidator : AbstractValidator<GetExportArticlesQuery>
    {
        public GetExportArticlesQueryValidator()
        {
            RuleFor(p => p.Code)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SourceASNNo)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Status)
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
