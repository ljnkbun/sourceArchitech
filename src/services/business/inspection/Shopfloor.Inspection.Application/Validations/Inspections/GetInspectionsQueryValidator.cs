using FluentValidation;
using Shopfloor.Inspection.Application.Query.Inspections;

namespace Shopfloor.Inspection.Application.Validations.Inspections
{
    public class GetInspectionsQueryValidator : AbstractValidator<GetInspectionsQuery>
    {
        public GetInspectionsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));
            		
		
			RuleFor(p => p.Reason).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.Remark).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.Line).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.Stage).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.CuttingTable).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
    }
}
