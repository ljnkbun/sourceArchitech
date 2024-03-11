using FluentValidation;
using Shopfloor.Inspection.Application.Query.InspectionDefectCapturings;

namespace Shopfloor.Inspection.Application.Validations.InspectionDefectCapturings
{
    public class GetInspectionDefectCapturingsQueryValidator : AbstractValidator<GetInspectionDefectCapturingsQuery>
    {
        public GetInspectionDefectCapturingsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));
            
        }
    }
}
