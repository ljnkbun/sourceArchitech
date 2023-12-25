using FluentValidation;
using Shopfloor.IED.Application.Command.Concentrates;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Concentrates
{
    public class UpdateConcentrateCommandValidator : AbstractValidator<UpdateConcentrateCommand>
    {
        private readonly IConcentrateRepository _concentrateRepository;
        public UpdateConcentrateCommandValidator(IConcentrateRepository concentrateRepository)
        {
            _concentrateRepository = concentrateRepository;
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
        private async Task<bool> IsUniqueAsync(UpdateConcentrateCommand command, CancellationToken token)
        {
            return await _concentrateRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
