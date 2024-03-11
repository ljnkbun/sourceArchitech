using FluentValidation;
using Shopfloor.Inspection.Application.Query.InspectionDefectError4PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectError4PointSyss
{
    public class GetInspectionDefectError4PointSyssQueryValidator : AbstractValidator<GetInspectionDefectError4PointSyssQuery>
    {
        public GetInspectionDefectError4PointSyssQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
