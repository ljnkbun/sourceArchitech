using FluentValidation;
using Shopfloor.Inspection.Application.Query.InspectionDefectError100PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectError100PointSyss
{
    public class GetInspectionDefectError100PointSyssQueryValidator : AbstractValidator<GetInspectionDefectError100PointSyssQuery>
    {
        public GetInspectionDefectError100PointSyssQueryValidator()
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
