using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingRappoMarks;

namespace Shopfloor.IED.Application.Validations.WeavingRappoMarks
{
    public class GetWeavingRappoMarksQueryValidator : AbstractValidator<GetWeavingRappoMarksQuery>
    {
        public GetWeavingRappoMarksQueryValidator()
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
