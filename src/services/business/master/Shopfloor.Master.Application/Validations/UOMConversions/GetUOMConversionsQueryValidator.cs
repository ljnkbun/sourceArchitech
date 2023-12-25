using FluentValidation;
using Shopfloor.Master.Application.Query.UOMConversions;

namespace Shopfloor.Master.Application.Validations.UOMConversions
{
    public class GetUOMConversionsQueryValidator : AbstractValidator<GetUOMConversionsQuery>
    {
        public GetUOMConversionsQueryValidator()
        {

            RuleFor(p => p.Action)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}
