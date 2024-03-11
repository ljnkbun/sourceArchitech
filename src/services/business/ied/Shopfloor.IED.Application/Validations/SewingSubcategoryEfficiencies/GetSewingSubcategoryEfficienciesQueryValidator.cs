using FluentValidation;
using Shopfloor.IED.Application.Query.SewingSubcategoryEfficiencies;

namespace Shopfloor.IED.Application.Validations.SewingSubcategoryEfficiencies
{
    public class GetSewingSubcategoryEfficienciesQueryValidator : AbstractValidator<GetSewingSubcategoryEfficienciesQuery>
    {
        public GetSewingSubcategoryEfficienciesQueryValidator()
        {
            RuleFor(p => p.SubCategory)
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