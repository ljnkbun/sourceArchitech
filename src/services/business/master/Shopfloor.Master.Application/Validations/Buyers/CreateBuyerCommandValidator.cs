using FluentValidation;
using Shopfloor.Master.Application.Command.Buyers;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Buyers
{
    public class CreateBuyerCommandValidator : AbstractValidator<CreateBuyerCommand>
    {
        private readonly IBuyerRepository _buyerRepository;
        public CreateBuyerCommandValidator(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
            RuleFor(p => p.WFXBuyerId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string WFXBuyerId, CancellationToken cancellationToken)
        {
            return await _buyerRepository.IsUniqueAsync(WFXBuyerId);
        }
    }
}
