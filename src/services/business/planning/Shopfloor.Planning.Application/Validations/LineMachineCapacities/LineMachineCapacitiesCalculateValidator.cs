using FluentValidation;
using Shopfloor.Planning.Application.Command.LineMachineCapacities;

namespace Shopfloor.Planning.Application.Validations.LineMachineCapacitys
{
    public class LineMachineCapacitiesCalculateValidator : AbstractValidator<CalculateLineMachineCapacitiesCommand>
    {
        public LineMachineCapacitiesCalculateValidator()
        {
            RuleFor(r => r.PlanningGroupId).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.FromDate).NotEmpty().WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ToDate).NotEmpty().WithMessage("{PropertyName}  is required.");
        }
    }
}
