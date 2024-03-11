using FluentValidation;
using Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingMachineEfficiencyProfiles
{
    public class UpdateSewingMachineEfficiencyProfileCommandValidator : AbstractValidator<UpdateSewingMachineEfficiencyProfileCommand>
    {
        private readonly ISewingMachineEfficiencyProfileRepository _repository;
        private readonly ISewingEfficiencyProfileRepository _sewingEfficiencyProfile;

        public UpdateSewingMachineEfficiencyProfileCommandValidator(ISewingEfficiencyProfileRepository sewingEfficiencyProfile, ISewingMachineEfficiencyProfileRepository repository)
        {
            _repository = repository;
            _sewingEfficiencyProfile = sewingEfficiencyProfile;

            RuleFor(p => p.SewingEfficiencyProfileId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.MachineName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.MachineId)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 0.");

            RuleFor(p => p).MustAsync(IsMachineUniqueAsync).WithMessage("MachineId must unique.");
        }

        private async Task<bool> IsExistAsync(int sewingEfficiencyProfileId, CancellationToken token)
        {
            return await _sewingEfficiencyProfile.IsExistAsync(sewingEfficiencyProfileId);
        }
        private async Task<bool> IsMachineUniqueAsync(UpdateSewingMachineEfficiencyProfileCommand command, CancellationToken token)
        {
            return await _repository.IsMachineUniqueAsync(command.MachineId, command.Id);
        }
    }
}