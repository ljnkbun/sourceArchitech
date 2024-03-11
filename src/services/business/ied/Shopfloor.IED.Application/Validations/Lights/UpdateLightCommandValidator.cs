using FluentValidation;
using Shopfloor.IED.Application.Command.Lights;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Lights
{
    public class UpdateLightCommandValidator : AbstractValidator<UpdateLightCommand>
    {
        private readonly ILightRepository _lightRepository;
        public UpdateLightCommandValidator(ILightRepository lightRepository)
        {
            _lightRepository = lightRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateLightCommand command, CancellationToken token)
        {
            return await _lightRepository.IsNameUniqueAsync(command.Name, command.Id);
        }
    }
}
