using FluentValidation;
using Shopfloor.Master.Application.Command.Patterns;
using Shopfloor.Master.Application.Command.PaymentTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.PaymentTerms
{
    public class UpdatePaymentTermCommandValidator : AbstractValidator<UpdatePaymentTermCommand>
    {
        private readonly IPaymentTermRepository _paymentTermRepository;
        public UpdatePaymentTermCommandValidator(IPaymentTermRepository paymentTermRepository)
        {
            _paymentTermRepository = paymentTermRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CreditDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdatePaymentTermCommand command, CancellationToken cancellationToken)
        {
            return await _paymentTermRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
