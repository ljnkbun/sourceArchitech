using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingIEDs;

namespace Shopfloor.IED.Application.Validations.DyeingIEDs
{
    public class GetSearchDyeingIEDsQueryValidator : AbstractValidator<GetSearchDyeingIEDsQuery>
    {
        public GetSearchDyeingIEDsQueryValidator()
        {
            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}