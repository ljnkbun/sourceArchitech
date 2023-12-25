using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMacroLibs;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingMacroLibs
{
    public class UpdateSewingMacroLibCommandValidator : AbstractValidator<UpdateSewingMacroLibCommand>
    {
        private readonly ISewingMacroLibRepository _sewingMacroLibRepository;
        public UpdateSewingMacroLibCommandValidator(ISewingMacroLibRepository sewingMacroLibRepository)
        {
            _sewingMacroLibRepository = sewingMacroLibRepository;

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

        private async Task<bool> IsUniqueAsync(UpdateSewingMacroLibCommand command, CancellationToken token)
        {
            return await _sewingMacroLibRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
