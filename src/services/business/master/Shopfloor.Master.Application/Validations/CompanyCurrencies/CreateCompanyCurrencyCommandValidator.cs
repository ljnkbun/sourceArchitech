using FluentValidation;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.CompanyCurrencies
{
    public class CreateCompanyCurrencyCommandValidator : AbstractValidator<CompanyCurrency>
    {
        private readonly ICompanyCurrencyRepository _companyCurrencyRepository;
        public CreateCompanyCurrencyCommandValidator(ICompanyCurrencyRepository companyCurrencyRepository)
        {
            _companyCurrencyRepository = companyCurrencyRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _companyCurrencyRepository.IsUniqueAsync(code);
        }
    }
}
