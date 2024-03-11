using FluentValidation;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturingTCStandards;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectCapturingTCStandards
{
    public class GetInspectionDefectCapturingTCStandardsQueryValidator : AbstractValidator<GetInspectionDefectCapturingTCStandardsQuery>
    {
        public GetInspectionDefectCapturingTCStandardsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
            RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
    }
}
