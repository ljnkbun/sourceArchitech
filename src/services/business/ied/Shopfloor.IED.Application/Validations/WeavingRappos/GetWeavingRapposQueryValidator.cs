using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingRappos;

namespace Shopfloor.IED.Application.Validations.WeavingRappos
{
    public class GetWeavingRapposQueryValidator : AbstractValidator<GetWeavingRapposQuery>
    {
        public GetWeavingRapposQueryValidator()
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
