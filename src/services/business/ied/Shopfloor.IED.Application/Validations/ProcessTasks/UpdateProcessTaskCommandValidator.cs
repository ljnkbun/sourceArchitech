using FluentValidation;
using Shopfloor.IED.Application.Command.ProcessTasks;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.ProcessTasks
{
    public class UpdateProcessTaskCommandValidator : AbstractValidator<UpdateProcessTaskCommand>
    {
        private readonly IProcessTaskRepository _processTaskRepository;
        public UpdateProcessTaskCommandValidator(IProcessTaskRepository processTaskRepository)
        {
            _processTaskRepository = processTaskRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateProcessTaskCommand command, CancellationToken token)
        {
            return await _processTaskRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
