using FluentValidation;
using Shopfloor.Barcode.Application.Query.ExportDetails;

namespace Shopfloor.Barcode.Application.Validations.ExportDetails
{
    public class GetExportDetailsQueryValidator : AbstractValidator<GetExportDetailsQuery>
    {
        public GetExportDetailsQueryValidator()
        {
            RuleFor(p => p.Code)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");  
            
            RuleFor(p => p.ExportArticleId)
                .GreaterThan(0).WithMessage("{PropertyName} must null or greater than 0.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

        }
    }
}
