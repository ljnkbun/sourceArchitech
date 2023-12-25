using FluentValidation;
using Shopfloor.IED.Application.Query.RecipeChemicals;

namespace Shopfloor.IED.Application.Validations.RecipeChemicals
{
    public class GetRecipeChemicalsQueryValidator : AbstractValidator<GetRecipeChemicalsQuery>
    {
        public GetRecipeChemicalsQueryValidator()
        {
            RuleFor(p => p.Unit)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ChemicalCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ChemicalName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.CreatedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));

            RuleFor(p => p.ModifiedDate)
                .LessThan(DateTime.Now.AddDays(1))
                .GreaterThan(new DateTime(1970, 1, 1));
        }
    }
}