using FluentValidation;
using Shopfloor.Master.Application.Command.SpinningMethods;
using Shopfloor.Master.Application.Command.SpinningProcesses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SpinningProcesses
{
    public class UpdateSpinningProcessCommandValidator : AbstractValidator<UpdateSpinningProcessCommand>
    {
        private readonly ISpinningProcessRepository _spinningProcessRepository;
        public UpdateSpinningProcessCommandValidator(ISpinningProcessRepository spinningProcessRepository)
        {
            _spinningProcessRepository = spinningProcessRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateSpinningProcessCommand command, CancellationToken cancellationToken)
        {
            return await _spinningProcessRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
