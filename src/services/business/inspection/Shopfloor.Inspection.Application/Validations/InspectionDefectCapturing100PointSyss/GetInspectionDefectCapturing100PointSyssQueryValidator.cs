using FluentValidation;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturing100PointSyss;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectCapturing100PointSyss
{
    public class GetInspectionDefectCapturing100PointSyssQueryValidator : AbstractValidator<GetInspectionDefectCapturing100PointSyssQuery>
    {
        public GetInspectionDefectCapturing100PointSyssQueryValidator()
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
