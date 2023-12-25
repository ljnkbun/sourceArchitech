using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBRCValues;

namespace Shopfloor.IED.Application.Validations.DyeingTBRCValues
{
    public class GetDyeingTBRCValuesQueryValidator : AbstractValidator<GetDyeingTBRCValuesQuery>
    {
        public GetDyeingTBRCValuesQueryValidator()
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