using FluentValidation;
using Shopfloor.IED.Application.Command.SewingSubcategoryEfficiencies;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingSubcategoryEfficiencies
{
    public class CreateSewingSubcategoryEfficiencyCommandValidator : AbstractValidator<CreateSewingSubcategoryEfficiencyCommand>
    {
        private readonly ISewingEfficiencyProfileRepository _sewingEfficiencyProfile;

        private readonly ISewingSubcategoryEfficiencyRepository _sewingSubcategoryEfficiency;

        public CreateSewingSubcategoryEfficiencyCommandValidator(ISewingEfficiencyProfileRepository sewingEfficiencyProfile, ISewingSubcategoryEfficiencyRepository sewingSubcategoryEfficiency)
        {
            _sewingEfficiencyProfile = sewingEfficiencyProfile;
            _sewingSubcategoryEfficiency = sewingSubcategoryEfficiency;

            RuleFor(p => p.SewingEfficiencyProfileId)
                .MustAsync(IsExistAsync)
                .WithMessage("Code not found.");

            RuleFor(p => p.SubCategory)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueSubCategoryAsync)
                .WithMessage("SubCategory must unique.")
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }

        private async Task<bool> IsExistAsync(int sewingEfficiencyProfileId, CancellationToken token)
        {
            return await _sewingEfficiencyProfile.IsExistAsync(sewingEfficiencyProfileId);
        }

        private async Task<bool> IsUniqueSubCategoryAsync(string subCategory, CancellationToken token)
        {
            return await _sewingSubcategoryEfficiency.IsUniqueSubCategoryAsync(subCategory);
        }
    }
}