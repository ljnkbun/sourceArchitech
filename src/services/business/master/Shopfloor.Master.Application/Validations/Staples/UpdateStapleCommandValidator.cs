using FluentValidation;
using Shopfloor.Master.Application.Command.SpinningProcesses;
using Shopfloor.Master.Application.Command.Staples;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Staples
{
    public class UpdateStapleCommandValidator : AbstractValidator<UpdateStapleCommand>
    {
        private readonly IStapleRepository _stapleRepository;
        public UpdateStapleCommandValidator(IStapleRepository stapleRepository)
        {
            _stapleRepository = stapleRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateStapleCommand command, CancellationToken cancellationToken)
        {
            return await _stapleRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
