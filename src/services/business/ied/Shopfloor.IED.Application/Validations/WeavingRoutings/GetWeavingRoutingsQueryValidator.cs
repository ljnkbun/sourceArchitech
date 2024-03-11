using FluentValidation;
using Shopfloor.IED.Application.Query.WeavingRoutings;

namespace Shopfloor.IED.Application.Validations.WeavingRoutings
{
    public class GetWeavingRoutingsQueryValidator : AbstractValidator<GetWeavingRoutingsQuery>
    {
        public GetWeavingRoutingsQueryValidator()
        {
            RuleFor(p => p.WeavingProcess)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.WeavingProcessCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}