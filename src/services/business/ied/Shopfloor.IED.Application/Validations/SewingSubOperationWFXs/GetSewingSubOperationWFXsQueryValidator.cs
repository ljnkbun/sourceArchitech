using FluentValidation;
using Shopfloor.IED.Application.Query.SewingSubOperationWFXs;

namespace Shopfloor.IED.Application.Validations.SewingSubOperationWFXs
{
    public class GetSewingSubOperationWFXsQueryValidator : AbstractValidator<GetSewingSubOperationWFXsQuery>
    {
        public GetSewingSubOperationWFXsQueryValidator()
        {
            RuleFor(p => p.WFXProcessCode)
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.WFXProcessName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.LineCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.LineNumber)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.QuatityPoints)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters."); 
            RuleFor(p => p.QualityComments)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.Freq)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
