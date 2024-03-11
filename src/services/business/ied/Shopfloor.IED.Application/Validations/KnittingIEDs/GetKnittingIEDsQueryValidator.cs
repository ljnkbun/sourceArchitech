using FluentValidation;
using Shopfloor.IED.Application.Query.KnittingIEDs;

namespace Shopfloor.IED.Application.Validations.KnittingIEDs
{
    public class GetKnittingIEDsQueryValidator : AbstractValidator<GetKnittingIEDsQuery>
    {
        public GetKnittingIEDsQueryValidator()
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
