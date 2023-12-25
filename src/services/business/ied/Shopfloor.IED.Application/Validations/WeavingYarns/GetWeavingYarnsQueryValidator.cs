using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingYarns;

namespace Shopfloor.IED.Application.Validations.WeavingYarns
{
    public class GetWeavingYarnsQueryValidator : AbstractValidator<GetWeavingYarnsQuery>
    {
        public GetWeavingYarnsQueryValidator()
        {
            RuleFor(p => p.YarnCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.YarnName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
