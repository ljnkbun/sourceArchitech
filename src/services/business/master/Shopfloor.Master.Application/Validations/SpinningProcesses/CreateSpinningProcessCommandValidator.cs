using FluentValidation;
using Shopfloor.Master.Application.Command.SpinningProcesses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SpinningProcesss
{
    public class CreateSpinningProcessCommandValidator : AbstractValidator<CreateSpinningProcessCommand>
    {
        private readonly ISpinningProcessRepository _spinningProcessRepository;
        public CreateSpinningProcessCommandValidator(ISpinningProcessRepository spinningProcessRepository)
        {
            _spinningProcessRepository = spinningProcessRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _spinningProcessRepository.IsUniqueAsync(code);
        }
    }
}
