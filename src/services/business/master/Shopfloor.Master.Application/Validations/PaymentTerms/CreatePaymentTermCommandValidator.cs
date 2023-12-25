using FluentValidation;
using Shopfloor.Master.Application.Command.PaymentTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.PaymentTerms
{
    public class CreatePaymentTermCommandValidator : AbstractValidator<CreatePaymentTermCommand>
    {
        private readonly IPaymentTermRepository _paymentTermRepository;
        public CreatePaymentTermCommandValidator(IPaymentTermRepository paymentTermRepository)
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

            RuleFor(p => p.CreditDays)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

            _paymentTermRepository = paymentTermRepository;
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _paymentTermRepository.IsUniqueAsync(code);
        }
    }
}
