using FluentValidation;
using Shopfloor.Barcode.Application.Query.Imports;

namespace Shopfloor.Barcode.Application.Validations.Imports
{
    public class GetImportsQueryValidator : AbstractValidator<GetImportsQuery>
    {
        public GetImportsQueryValidator()
        {
            RuleFor(p => p.Code)
               .MaximumLength(200).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Name)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Note)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Status)
               .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

        }
    }
}
