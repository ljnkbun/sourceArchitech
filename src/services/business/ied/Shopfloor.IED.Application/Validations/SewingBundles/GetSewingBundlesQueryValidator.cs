using FluentValidation;
using Shopfloor.IED.Application.Query.SewingBundles;

namespace Shopfloor.IED.Application.Validations.SewingBundles
{
    public class GetSewingBundlesQueryValidator : AbstractValidator<GetSewingBundlesQuery>
    {
        public GetSewingBundlesQueryValidator()
        {
            RuleFor(p => p.Code)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

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