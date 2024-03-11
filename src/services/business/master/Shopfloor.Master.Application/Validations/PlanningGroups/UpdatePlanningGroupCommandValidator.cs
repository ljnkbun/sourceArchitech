using FluentValidation;
using Shopfloor.Master.Application.Command.PlanningGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.PlanningGroups
{
    public class UpdatePlanningGroupCommandValidator : AbstractValidator<UpdatePlanningGroupCommand>
    {
        private readonly IPlanningGroupRepository _planningGroupRepository;
        public UpdatePlanningGroupCommandValidator(IPlanningGroupRepository planningGroupRepository)
        {
            _planningGroupRepository = planningGroupRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p)
                .MustAsync(IsUniqueAsync)
                .WithMessage("{PropertyName} must unique.")
                .MustAsync(IsProcessIdExist)
                .WithMessage("{PropertyName} is already exist.");
        }

        private async Task<bool> IsUniqueAsync(UpdatePlanningGroupCommand command, CancellationToken token)
        {
            return await _planningGroupRepository.IsUniqueAsync(command.Code, command.Id);
        }

        private async Task<bool> IsProcessIdExist(UpdatePlanningGroupCommand command, CancellationToken token)
        {
            return await _planningGroupRepository.IsProcessIdExits(command.ProcessId, command.Id);
        }
    }
}
