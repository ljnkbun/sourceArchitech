using FluentValidation;
using Shopfloor.Planning.Application.Query.LineMachineCapacities;

namespace Shopfloor.Planning.Application.Validations.LineMachineCapacitys
{
    public class GetLineMachineCapacitysQueryValidator : AbstractValidator<GetLineMachineCapacitiesQuery>
    {
        public GetLineMachineCapacitysQueryValidator()
        {
            RuleFor(r => r.PlanningGroupId).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.FromDate).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToDate).NotEmpty().WithMessage("{PropertyName}  is required.");
        }
    }
}
