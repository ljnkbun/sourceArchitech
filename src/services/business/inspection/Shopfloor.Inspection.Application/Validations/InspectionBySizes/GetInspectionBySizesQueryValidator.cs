using FluentValidation;
using Shopfloor.Inspection.Application.Query.InspectionBySizes;

namespace Shopfloor.Inspection.Application.Validations.InspectionBySizes
{
    public class GetInspectionBySizesQueryValidator : AbstractValidator<GetInspectionBySizesQuery>
    {
        public GetInspectionBySizesQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Local));
            RuleFor(p => p.ColorCode).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
			RuleFor(p => p.ColorName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.SizeCode).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
			RuleFor(p => p.SizeName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.Shade).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
			RuleFor(p => p.Lot).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
			RuleFor(p => p.ReasonforBGroup).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
    }
}
