using FluentValidation;
using Shopfloor.Master.Application.Command.Currencies;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Currencies
{
    public class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand>
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CreateCurrencyCommandValidator(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
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
            return await _currencyRepository.IsUniqueAsync(code);
        }
    }
}
