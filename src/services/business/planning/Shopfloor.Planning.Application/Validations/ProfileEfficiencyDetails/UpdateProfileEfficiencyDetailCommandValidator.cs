using FluentValidation;
using Shopfloor.Planning.Application.Command.ProfileEfficiencyDetails;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.ProfileEfficiencyDetails
{
    public class UpdateProfileEfficiencyDetailCommandValidator : AbstractValidator<UpdateProfileEfficiencyDetailCommand>
    {
        private readonly IProfileEfficiencyDetailRepository _repository;
        private readonly IProfileEfficiencyRepository _profileEfficiencyRepository;

        public UpdateProfileEfficiencyDetailCommandValidator(IProfileEfficiencyDetailRepository repository,
            IProfileEfficiencyRepository profileEfficiencyRepository)
        {
            _repository = repository;
            _profileEfficiencyRepository = profileEfficiencyRepository;
         
            RuleFor(p => p.SubCategoryId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.SubCategoryCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.SubCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ProfileEfficiencyId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistProfileEfficiency).WithMessage("{PropertyName} not exists.");

            RuleFor(p => p.EfficiencyValue)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }

        private async Task<bool> IsExistProfileEfficiency(int id, CancellationToken cancellationToken)
        {
            return await _profileEfficiencyRepository.GetByIdAsync(id) != null;
        }
    }
}
