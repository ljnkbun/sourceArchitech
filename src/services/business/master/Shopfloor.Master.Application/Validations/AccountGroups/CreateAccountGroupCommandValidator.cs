using FluentValidation;
using Shopfloor.Master.Application.Command.AccountGroups;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.AccountGroups
{
    public class CreateAccountGroupCommandValidator : AbstractValidator<CreateAccountGroupCommand>
    {
        private readonly IAccountGroupRepository _accountGroupRepository;
        public CreateAccountGroupCommandValidator(IAccountGroupRepository accountGroupRepository)
        {
            _accountGroupRepository = accountGroupRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _accountGroupRepository.IsUniqueAsync(code);
        }
    }
}
