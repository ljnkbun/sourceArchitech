using FluentValidation;
using Shopfloor.Master.Application.Command.AccountGroups;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.AccountGroups
{
    public class UpdateAccountGroupCommandValidator : AbstractValidator<UpdateAccountGroupCommand>
    {
        private readonly IAccountGroupRepository _accountGroupRepository;
        public UpdateAccountGroupCommandValidator(IAccountGroupRepository accountGroupRepository)
        {
            _accountGroupRepository = accountGroupRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateAccountGroupCommand command, CancellationToken token)
        {
            return await _accountGroupRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
