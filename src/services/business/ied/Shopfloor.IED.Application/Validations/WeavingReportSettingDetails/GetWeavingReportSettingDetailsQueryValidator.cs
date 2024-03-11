using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingReportSettingDetails;

namespace Shopfloor.IED.Application.Validations.WeavingReportSettingDetails
{
    public class GetWeavingReportSettingDetailsQueryValidator : AbstractValidator<GetWeavingReportSettingDetailsQuery>
    {
        public GetWeavingReportSettingDetailsQueryValidator()
        {
            RuleFor(p => p.Split)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}