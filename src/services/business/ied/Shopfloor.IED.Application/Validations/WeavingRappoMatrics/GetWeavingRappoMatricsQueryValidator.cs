using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingRappoMatrics;

namespace Shopfloor.IED.Application.Validations.WeavingRappoMatrics
{
    public class GetWeavingRappoMatricsQueryValidator : AbstractValidator<GetWeavingRappoMatricsQuery>
    {
        public GetWeavingRappoMatricsQueryValidator()
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
