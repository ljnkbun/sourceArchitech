using FluentValidation;
using Shopfloor.Barcode.Application.Query.AppVersions;

namespace Shopfloor.Barcode.Application.Validations.AppVersions
{
    public class GetAppVersionsQueryValidator : AbstractValidator<GetAppVersionsQuery>
    {
        public GetAppVersionsQueryValidator()
        {

            RuleFor(p => p.Name)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}