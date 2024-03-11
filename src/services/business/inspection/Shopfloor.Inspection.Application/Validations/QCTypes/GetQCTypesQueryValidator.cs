using FluentValidation;
using Shopfloor.Inspection.Application.Query.QCTypes;

namespace Shopfloor.Inspection.Application.Validations.QCTypes
{
    public class GetQCTypesQueryValidator : AbstractValidator<GetQCTypesQuery>
    {
        public GetQCTypesQueryValidator()
        {
            RuleFor(p => p.Code)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
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
