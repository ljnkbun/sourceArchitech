using FluentValidation;
using Shopfloor.IED.Application.Query.FormulaFields;

namespace Shopfloor.IED.Application.Validations.FormulaFields
{
    public class GetFormulaFieldsQueryValidator : AbstractValidator<GetFormulaFieldsQuery>
    {
        public GetFormulaFieldsQueryValidator()
        {
            RuleFor(p => p.FieldName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ProcessCode)
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
