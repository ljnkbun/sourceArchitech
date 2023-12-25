using FluentValidation;
using Shopfloor.Material.Application.Command.Buyers;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Validations.Buyers
{
    public class CreateBuyerCommandValidator : AbstractValidator<CreateBuyerCommand>
    {
        private readonly IBuyerRepository _repository;
        public CreateBuyerCommandValidator(IBuyerRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.ShortName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.Currency)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.ContactFirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.ContactLastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.BuyerType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}