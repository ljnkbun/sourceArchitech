using FluentValidation;
using Shopfloor.IED.Application.Query.Requests;

namespace Shopfloor.IED.Application.Validations.Requests
{
    public class GetRequestsQueryValidator : AbstractValidator<GetRequestsQuery>
    {
        public GetRequestsQueryValidator()
        {
            RuleFor(p => p.RequestNo)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

        }
    }
}
