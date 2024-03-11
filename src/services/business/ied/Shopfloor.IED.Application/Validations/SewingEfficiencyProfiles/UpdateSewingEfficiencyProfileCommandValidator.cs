using FluentValidation;
using Shopfloor.IED.Application.Command.SewingEfficiencyProfiles;
using Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingEfficiencyProfiles
{
    public class UpdateSewingEfficiencyProfileCommandValidator : AbstractValidator<UpdateSewingEfficiencyProfileCommand>
    {
        private readonly ISewingEfficiencyProfileRepository _sewingEfficiencyProfile;
        private readonly ISewingMachineEfficiencyProfileRepository _machineRepository;

        public UpdateSewingEfficiencyProfileCommandValidator(ISewingEfficiencyProfileRepository sewingEfficiencyProfile, ISewingMachineEfficiencyProfileRepository machineRepository)
        {
            _sewingEfficiencyProfile = sewingEfficiencyProfile;
            _machineRepository = machineRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.MachineDelay)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");

            RuleFor(p => p.Contingency)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");

            RuleFor(p => p.PersonalAllowance)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");

            RuleFor(p => p).MustAsync(IsOnlyOneDefaultAsync).WithMessage("Only one default Efficiency Profile.");

            RuleFor(p => p).Must(IsMachineUnique).WithMessage("MachineId must unique.");

            RuleForEach(p => p.SewingMachineEfficiencyProfiles).ChildRules(childSewingMachineEfficiencyProfile =>
            {
                childSewingMachineEfficiencyProfile.RuleFor(p => p.MachineName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childSewingMachineEfficiencyProfile.RuleFor(p => p.MachineId)
                    .GreaterThan(0).WithMessage("{PropertyName} must greater than 0.");

                childSewingMachineEfficiencyProfile.RuleFor(p => p.SewingEfficiencyProfileId)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MustAsync(IsExistAsync)
                    .WithMessage("{PropertyName} not found.");

                childSewingMachineEfficiencyProfile.RuleFor(p => p).MustAsync(IsMachineUniqueAsync).WithMessage("MachineId must unique.");
            });

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSewingEfficiencyProfileCommand command, CancellationToken token)
        {
            return await _sewingEfficiencyProfile.IsNameUniqueAsync(command.Name, command.Id);
        }

        private async Task<bool> IsExistAsync(int sewingEfficiencyProfileId, CancellationToken token)
        {
            return await _sewingEfficiencyProfile.IsExistAsync(sewingEfficiencyProfileId);
        }
        private async Task<bool> IsOnlyOneDefaultAsync(UpdateSewingEfficiencyProfileCommand command, CancellationToken token)
        {
            if (command.IsDefault == true)
            {
                var defaultEfficiency = await _sewingEfficiencyProfile.GetDefaultSewingEfficiencyProfileAsync();
                if (defaultEfficiency != null && command.Id != defaultEfficiency.Id)
                    return false;
            }
            return true;
        }
        private bool IsMachineUnique(UpdateSewingEfficiencyProfileCommand command)
        {
            return command.SewingMachineEfficiencyProfiles?.DistinctBy(m => m.MachineId).Count() == command.SewingMachineEfficiencyProfiles?.Count;
        }
        private async Task<bool> IsMachineUniqueAsync(UpdateSewingMachineEfficiencyProfileCommand command, CancellationToken token)
        {
            return await _machineRepository.IsMachineUniqueAsync(command.MachineId, command.SewingEfficiencyProfileId);
        }
    }
}