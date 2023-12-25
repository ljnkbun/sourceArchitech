using FluentValidation;
using Shopfloor.Master.Application.Command.Currencies;
using Shopfloor.Master.Application.Command.DeliveryTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.DeliveryTerms
{
    public class UpdateDeliveryTermCommandValidator : AbstractValidator<UpdateDeliveryTermCommand>
    {
        private readonly IDeliveryTermRepository _deliveryTermRepository;
        public UpdateDeliveryTermCommandValidator(IDeliveryTermRepository deliveryTermRepository)
        {
            _deliveryTermRepository = deliveryTermRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateDeliveryTermCommand command, CancellationToken cancellationToken)
        {
            return await _deliveryTermRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
