using FluentValidation;
using Shopfloor.Inspection.Application.Query.QCDefects;

namespace Shopfloor.Inspection.Application.Validations.QCDefects
{
    public class GetQCDefectsQueryValidator : AbstractValidator<GetQCDefectsQuery>
    {
        public GetQCDefectsQueryValidator()
        {
            RuleFor(p => p.Code)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local));
            RuleFor(p => p.NameEN).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.DivisonName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.ProcessName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.CategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.SubCategoryId).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.SubCategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
    }
}
