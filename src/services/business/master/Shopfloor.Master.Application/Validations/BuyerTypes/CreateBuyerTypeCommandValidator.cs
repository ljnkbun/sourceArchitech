using FluentValidation;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.BuyerTypes
{
    public class CreateBuyerTypeCommandValidator : AbstractValidator<CreateBuyerTypeCommand>
    {
        private readonly IBuyerTypeRepository _buyerTypeRepository;
        public CreateBuyerTypeCommandValidator(IBuyerTypeRepository buyerTypeRepository)
        {
            _buyerTypeRepository = buyerTypeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _buyerTypeRepository.IsUniqueAsync(code);
        }
    }
}
