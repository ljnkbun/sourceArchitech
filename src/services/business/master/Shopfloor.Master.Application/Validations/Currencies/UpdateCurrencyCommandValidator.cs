using FluentValidation;
using Shopfloor.Master.Application.Command.CropSeasons;
using Shopfloor.Master.Application.Command.Currencies;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Currencies
{
    public class UpdateCurrencyCommandValidator : AbstractValidator<UpdateCurrencyCommand>
    {
        private readonly ICurrencyRepository _currencyRepository;
        public UpdateCurrencyCommandValidator(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateCurrencyCommand command, CancellationToken cancellationToken)
        {
            return await _currencyRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
