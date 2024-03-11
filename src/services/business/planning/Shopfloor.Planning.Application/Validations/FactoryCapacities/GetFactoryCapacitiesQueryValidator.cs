using FluentValidation;
using Shopfloor.Planning.Application.Query.FactoryCapacitys;

namespace Shopfloor.Planning.Application.Validations.FactoryCapacitys
{
    public class GetFactoryCapacitiesQueryValidator : AbstractValidator<GetFactoryCapacitiesQuery>
    {
        public GetFactoryCapacitiesQueryValidator()
        {
            RuleFor(r => r.FromDate).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToDate).NotEmpty().WithMessage("{PropertyName}  is required.");
        }
    }
}
