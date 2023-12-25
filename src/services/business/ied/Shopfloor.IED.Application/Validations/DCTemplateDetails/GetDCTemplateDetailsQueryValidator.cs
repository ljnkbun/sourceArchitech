using FluentValidation;
using Shopfloor.IED.Application.Query.DCTemplateDetails;

namespace Shopfloor.IED.Application.Validations.DCTemplateDetails
{
    public class GetDCTemplateDetailsQueryValidator : AbstractValidator<GetDCTemplateDetailsQuery>
    {
        public GetDCTemplateDetailsQueryValidator()
        {
            RuleFor(p => p.ChemicalCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ChemicalName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Unit)
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