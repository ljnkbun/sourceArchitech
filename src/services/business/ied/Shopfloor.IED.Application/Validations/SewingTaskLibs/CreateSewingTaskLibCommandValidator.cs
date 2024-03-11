using FluentValidation;
using Shopfloor.IED.Application.Command.SewingTaskLibs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingTaskLibs
{
    public class CreateSewingTaskLibCommandValidator : AbstractValidator<CreateSewingTaskLibCommand>
    {
        private readonly ISewingTaskLibRepository _sewingTaskLibRepository;
        public CreateSewingTaskLibCommandValidator(ISewingTaskLibRepository sewingTaskLibRepository)
        {
            _sewingTaskLibRepository = sewingTaskLibRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.MachineName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.TaskType).IsInEnum();
            RuleFor(p => p).Must(IsDataValid).WithMessage("Data invalid.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _sewingTaskLibRepository.IsUniqueAsync(code);
        }
        private bool IsDataValid(CreateSewingTaskLibCommand command)
        {
            if ((command.TaskType == TaskType.BU && (command.SewingBundleId == null || command.SewingBundleId == 0))
                || (command.TaskType != TaskType.BU && command.SewingBundleId != null))
            {
                return false;
            }
            return true;
        }
    }
}
