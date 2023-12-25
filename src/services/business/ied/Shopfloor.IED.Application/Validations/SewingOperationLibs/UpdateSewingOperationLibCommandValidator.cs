using FluentValidation;
using Shopfloor.IED.Application.Command.SewingOperationLibs;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingOperationLibs
{
    public class UpdateSewingOperationLibCommandValidator : AbstractValidator<UpdateSewingOperationLibCommand>
    {
        private readonly ISewingOperationLibRepository _sewingOperationLibRepository;
        public UpdateSewingOperationLibCommandValidator(ISewingOperationLibRepository sewingOperationLibRepository)
        {
            _sewingOperationLibRepository = sewingOperationLibRepository;

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

        private async Task<bool> IsUniqueAsync(UpdateSewingOperationLibCommand command, CancellationToken token)
        {
            return await _sewingOperationLibRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
