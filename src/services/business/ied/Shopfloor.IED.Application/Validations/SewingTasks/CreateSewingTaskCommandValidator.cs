using FluentValidation;
using Shopfloor.IED.Application.Command.SewingTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingTasks
{
    public class CreateSewingTaskCommandValidator : AbstractValidator<CreateSewingTaskCommand>
    {
        private readonly ISewingTaskRepository _SewingTaskRepository;
        public CreateSewingTaskCommandValidator(ISewingTaskRepository SewingTaskRepository)
        {
            _SewingTaskRepository = SewingTaskRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Freq)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _SewingTaskRepository.IsUniqueAsync(code);
        }
    }
}
