using FluentValidation;
using Shopfloor.IED.Application.Command.SewingEfficiencyProfiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingEfficiencyProfiles
{
    public class CreateSewingEfficiencyProfileCommandValidator : AbstractValidator<CreateSewingEfficiencyProfileCommand>
    {
        private readonly ISewingEfficiencyProfileRepository _sewingEfficiencyProfile;
        private readonly ISewingSubcategoryEfficiencyRepository _sewingSubcategoryEfficiency;
        private readonly ISewingMachineEfficiencyProfileRepository _machineRepository;

        public CreateSewingEfficiencyProfileCommandValidator(ISewingEfficiencyProfileRepository sewingEfficiencyProfile, ISewingSubcategoryEfficiencyRepository sewingSubcategoryEfficiency, ISewingMachineEfficiencyProfileRepository machineRepository)
        {
            _sewingEfficiencyProfile = sewingEfficiencyProfile;
            _sewingSubcategoryEfficiency = sewingSubcategoryEfficiency;
            _machineRepository = machineRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueAsync)
                .WithMessage("{PropertyName} must unique.")
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.MachineDelay)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");

            RuleFor(p => p.Contingency)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");

            RuleFor(p => p.PersonalAllowance)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");

            RuleFor(p => p).MustAsync(IsOnlyOneDefaultAsync).WithMessage("Only one default Efficiency Profile.");

            RuleFor(p => p).Must(IsMachineUnique).WithMessage("MachineId must unique.");

            RuleForEach(p => p.SewingSubcategoryEfficiencies).ChildRules(childSewingSubcategoryEfficiency =>
            {
                childSewingSubcategoryEfficiency.RuleFor(p => p.SubCategory)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MustAsync(IsUniqueSubCategoryAsync)
                    .WithMessage("SubCategory must unique.")
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            });

            RuleForEach(p => p.SewingMachineEfficiencyProfiles).ChildRules(childSewingMachineEfficiencyProfile =>
            {
                childSewingMachineEfficiencyProfile.RuleFor(p => p.MachineName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childSewingMachineEfficiencyProfile.RuleFor(p => p.MachineId)
                    .GreaterThan(0).WithMessage("{PropertyName} must greater than 0.")
                    .MustAsync(IsMachineUniqueAsync).WithMessage("{PropertyName} must unique.");
            });
        }

        private async Task<bool> IsUniqueAsync(string name, CancellationToken token)
        {
            return await _sewingEfficiencyProfile.IsNameUniqueAsync(name);
        }

        private async Task<bool> IsUniqueSubCategoryAsync(string subCategory, CancellationToken token)
        {
            return await _sewingSubcategoryEfficiency.IsUniqueSubCategoryAsync(subCategory);
        }
        private async Task<bool> IsOnlyOneDefaultAsync(CreateSewingEfficiencyProfileCommand command, CancellationToken token)
        {
            if (command.IsDefault == true)
            {
                var defaultEfficiency = await _sewingEfficiencyProfile.GetDefaultSewingEfficiencyProfileAsync();
                if (defaultEfficiency != null)
                    return false;
            }
            return true;
        }
        private bool IsMachineUnique(CreateSewingEfficiencyProfileCommand command)
        {
            return command.SewingMachineEfficiencyProfiles?.DistinctBy(m => m.MachineId).Count() == command.SewingMachineEfficiencyProfiles?.Count;
        }
        private async Task<bool> IsMachineUniqueAsync(int machineId, CancellationToken token)
        {
            return await _machineRepository.IsMachineUniqueAsync(machineId);
        }
    }
}