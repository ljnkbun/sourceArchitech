using FluentValidation;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Zones
{
    public class CreateZoneCommandValidator : AbstractValidator<CreateZoneCommand>
    {
        private readonly IZoneRepository _zoneRepository;
        public CreateZoneCommandValidator(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ZoneSalary)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _zoneRepository.IsUniqueAsync(code);
        }
    }
}
