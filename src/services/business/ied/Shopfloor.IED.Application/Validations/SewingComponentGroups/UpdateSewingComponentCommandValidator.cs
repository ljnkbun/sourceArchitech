using FluentValidation;
using Shopfloor.IED.Application.Command.SewingComponentGroups;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingComponentGroups
{
    public class UpdateSewingComponentGroupCommandValidator : AbstractValidator<UpdateSewingComponentGroupCommand>
    {
        private readonly ISewingComponentGroupRepository _repository;
        public UpdateSewingComponentGroupCommandValidator(ISewingComponentGroupRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateSewingComponentGroupCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
