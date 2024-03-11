using FluentValidation;
using Shopfloor.Inspection.Application.Query.ProblemCorrectiveActions;

namespace Shopfloor.Inspection.Application.Validations.ProblemCorrectiveActions
{
    public class GetProblemCorrectiveActionsQueryValidator : AbstractValidator<GetProblemCorrectiveActionsQuery>
    {
        public GetProblemCorrectiveActionsQueryValidator()
        {
            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local));
            RuleFor(p => p.NameVN).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.NameEN).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.DivisonName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.ProcessName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.CategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.SubCategoryName).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

        }
    }
}
