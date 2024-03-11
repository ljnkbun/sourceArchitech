using FluentValidation;
using Shopfloor.Planning.Application.Command.FactoryCapacities;

namespace Shopfloor.Planning.Application.Validations.FactoryCapacitys
{
    public class FactoryCapacitiesCalculateValidator : AbstractValidator<CalculateFactoryCapacitiesCommand>
    {
        public FactoryCapacitiesCalculateValidator()
        {
            RuleFor(r => r.FromDate).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToDate).NotEmpty().WithMessage("{PropertyName}  is required.");
        }
    }
}
