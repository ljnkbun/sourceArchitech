using FluentValidation;
using Shopfloor.Master.Application.Command.PlanningGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.PlanningGroups
{
    public class CreatePlanningGroupCommandValidator : AbstractValidator<CreatePlanningGroupCommand>
    {
        private readonly IPlanningGroupRepository _planningGroupRepository;
        public CreatePlanningGroupCommandValidator(IPlanningGroupRepository planningGroupRepository)
        {
            _planningGroupRepository = planningGroupRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ProcessId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsProcessIdExist).WithMessage("{PropertyName} is already exist.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _planningGroupRepository.IsUniqueAsync(code);
        }

        private async Task<bool> IsProcessIdExist(int processId, CancellationToken token)
        {
            return await _planningGroupRepository.IsProcessIdExits(processId);
        }
    }
}
