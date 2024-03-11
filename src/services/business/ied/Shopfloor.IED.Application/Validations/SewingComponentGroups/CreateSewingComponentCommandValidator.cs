using FluentValidation;
using Shopfloor.IED.Application.Command.SewingComponentGroups;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingComponentGroups
{
    public class CreateSewingComponentGroupCommandValidator : AbstractValidator<CreateSewingComponentGroupCommand>
    {
        private readonly ISewingComponentGroupRepository _repository;
        public CreateSewingComponentGroupCommandValidator(ISewingComponentGroupRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
