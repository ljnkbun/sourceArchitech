using FluentValidation;
using Shopfloor.Planning.Application.Command.ProfileEfficiencies;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.ProfileEfficiencies
{
    public class CreateProfileEfficiencyCommandValidator : AbstractValidator<CreateProfileEfficiencyCommand>
    {
        private readonly IProfileEfficiencyRepository _repository;
        public CreateProfileEfficiencyCommandValidator(IProfileEfficiencyRepository repository)
        {

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.ProductGroupId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            _repository = repository;
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
