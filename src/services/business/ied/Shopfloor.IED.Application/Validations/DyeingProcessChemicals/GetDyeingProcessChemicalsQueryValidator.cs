using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingProcessChemicals;

namespace Shopfloor.IED.Application.Validations.DyeingProcessChemicals
{
    public class GetDyeingProcessChemicalsQueryValidator : AbstractValidator<GetDyeingProcessChemicalsQuery>
    {
        public GetDyeingProcessChemicalsQueryValidator()
        {
            RuleFor(p => p.ChemicalCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ChemicalName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategoryCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.SubCategoryName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Unit)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));
        }
    }
}