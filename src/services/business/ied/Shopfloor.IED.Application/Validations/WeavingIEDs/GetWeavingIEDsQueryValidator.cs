using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingIEDs;

namespace Shopfloor.IED.Application.Validations.WeavingIEDs
{
    public class GetWeavingIEDsQueryValidator : AbstractValidator<GetWeavingIEDsQuery>
    {
        public GetWeavingIEDsQueryValidator()
        {
            RuleFor(p => p.RequestNo)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Comment)
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
