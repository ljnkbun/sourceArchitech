using FluentValidation;
using Shopfloor.Material.Application.Command.BuyerFiles;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Validations.BuyerFiles
{
    public class CreateBuyerFileCommandValidator : AbstractValidator<CreateBuyerFileCommand>
    {
        private readonly IBuyerRepository _buyer;

        public CreateBuyerFileCommandValidator(IBuyerRepository buyer)
        {
            _buyer = buyer;
            RuleFor(p => p.FileId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.FileName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.BuyerId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int buyerId, CancellationToken token)
        {
            return await _buyer.IsExistAsync(buyerId);
        }
    }
}