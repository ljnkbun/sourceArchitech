using FluentValidation;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Zones
{
    public class UpdateZoneCommandValidator : AbstractValidator<UpdateZoneCommand>
    {
        private readonly IZoneRepository _zoneRepository;
        public UpdateZoneCommandValidator(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ZoneSalary)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateZoneCommand command, CancellationToken token)
        {
            return await _zoneRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
