using FluentValidation;
using Shopfloor.Planning.Application.Query.ProfileEfficiencyDetails;

namespace Shopfloor.Planning.Application.Validations.ProfileEfficiencyDetails
{
    public class GetProfileEfficiencyDetailsQueryValidator : AbstractValidator<GetProfileEfficiencyDetailsQuery>
    {
        public GetProfileEfficiencyDetailsQueryValidator()
        {
            RuleFor(p => p.SubCategoryCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.SubCategoryName)
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
