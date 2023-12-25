using FluentValidation;
using Shopfloor.IED.Application.Query.DCTemplates;

namespace Shopfloor.IED.Application.Validations.DCTemplates
{
    public class GetDCTemplatesQueryValidator : AbstractValidator<GetDCTemplatesQuery>
    {
        public GetDCTemplatesQueryValidator()
        {
            RuleFor(p => p.Code)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Name)
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