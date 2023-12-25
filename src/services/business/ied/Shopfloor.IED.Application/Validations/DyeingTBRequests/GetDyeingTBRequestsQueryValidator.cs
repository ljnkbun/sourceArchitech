using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBRequests;

namespace Shopfloor.IED.Application.Validations.DyeingTBRequests
{
    public class GetDyeingTBRequestsQueryValidator : AbstractValidator<GetDyeingTBRequestsQuery>
    {
        public GetDyeingTBRequestsQueryValidator()
        {
            RuleFor(p => p.RequestNo)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Remark)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.StyleRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.BuyerRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RequestDate)
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ExpiredDate)
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}