using FluentValidation;
using Shopfloor.Master.Application.Command.Ports;
using Shopfloor.Master.Application.Command.PricePers;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.PricePers
{
    public class UpdatePricePerCommandValidator : AbstractValidator<UpdatePricePerCommand>
    {
        private readonly IPricePerRepository _pricePerRepository;
        public UpdatePricePerCommandValidator(IPricePerRepository pricePerRepository)
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            _pricePerRepository = pricePerRepository;

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdatePricePerCommand command, CancellationToken cancellationToken)
        {
            return await _pricePerRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
