using FluentValidation;
using Shopfloor.Inspection.Application.Query.InspectionMesurements;

namespace Shopfloor.Inspection.Application.Validations.InspectionMesurements
{
    public class GetInspectionMesurementsQueryValidator : AbstractValidator<GetInspectionMesurementsQuery>
    {
        public GetInspectionMesurementsQueryValidator()
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
