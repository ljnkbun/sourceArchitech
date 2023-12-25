using FluentValidation;
using Shopfloor.IED.Application.Command.SewingTasks;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingTasks
{
    public class UpdateSewingTaskCommandValidator : AbstractValidator<UpdateSewingTaskCommand>
    {
        private readonly ISewingTaskRepository _SewingTaskRepository;
        public UpdateSewingTaskCommandValidator(ISewingTaskRepository SewingTaskRepository)
        {
            _SewingTaskRepository = SewingTaskRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Freq)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSewingTaskCommand command, CancellationToken token)
        {
            return await _SewingTaskRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
