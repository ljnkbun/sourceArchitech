using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingReportSettings;

namespace Shopfloor.IED.Application.Validations.WeavingReportSettings
{
    public class GetWeavingReportSettingsQueryValidator : AbstractValidator<GetWeavingReportSettingsQuery>
    {
        public GetWeavingReportSettingsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}