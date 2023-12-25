using FluentValidation;
using Shopfloor.IED.Application.Query.DyeingTBRChemicals;

namespace Shopfloor.IED.Application.Validations.DyeingTBRChemicals
{
    public class GetDyeingTBRChemicalsQueryValidator : AbstractValidator<GetDyeingTBRChemicalsQuery>
    {
        public GetDyeingTBRChemicalsQueryValidator()
        {
            RuleFor(p => p.Unit)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ChemicalCode)
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(p => p.ChemicalName)
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