using FluentValidation;
using Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingSubcategoryEfficiencies
{
    public class UpdateSewingSubcategoryEfficiencyCommandValidator : AbstractValidator<UpdateSewingSubcategoryEfficiencyCommand>
    {
        private readonly ISewingEfficiencyProfileRepository _sewingEfficiencyProfile;

        private readonly ISewingSubcategoryEfficiencyRepository _sewingSubcategoryEfficiency;

        public UpdateSewingSubcategoryEfficiencyCommandValidator(ISewingEfficiencyProfileRepository sewingEfficiencyProfile, ISewingSubcategoryEfficiencyRepository sewingSubcategoryEfficiency)
        {
            _sewingEfficiencyProfile = sewingEfficiencyProfile;
            _sewingSubcategoryEfficiency = sewingSubcategoryEfficiency;

            RuleFor(p => p.SewingEfficiencyProfileId)
                .MustAsync(IsExistAsync)
                .WithMessage("Code not found.");

            RuleFor(p => p.SubCategory)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p).MustAsync(IsUniqueSubCategoryAsync).WithMessage("SubCategory must unique.");
        }

        private async Task<bool> IsExistAsync(int sewingEfficiencyProfileId, CancellationToken token)
        {
            return await _sewingEfficiencyProfile.IsExistAsync(sewingEfficiencyProfileId);
        }
        private async Task<bool> IsUniqueSubCategoryAsync(UpdateSewingSubcategoryEfficiencyCommand command, CancellationToken token)
        {
            return await _sewingSubcategoryEfficiency.IsUniqueSubCategoryAsync(command.SubCategory, command.Id);
        }
    }
}