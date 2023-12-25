using FluentValidation;
using Shopfloor.IED.Application.Command.ProcessTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.ProcessTasks
{
    public class CreateProcessTaskCommandValidator : AbstractValidator<CreateProcessTaskCommand>
    {
        private readonly IProcessTaskRepository _processTaskRepository;
        public CreateProcessTaskCommandValidator(IProcessTaskRepository processTaskRepository)
        {
            _processTaskRepository = processTaskRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _processTaskRepository.IsUniqueAsync(code);
        }
    }
}
