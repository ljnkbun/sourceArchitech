using FluentValidation;
using Shopfloor.Master.Application.Command.Staples;
using Shopfloor.Master.Application.Command.Strengths;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Strengths
{
    public class UpdateStrengthCommandValidator : AbstractValidator<UpdateStrengthCommand>
    {
        private readonly IStrengthRepository _strengthRepository;
        public UpdateStrengthCommandValidator(IStrengthRepository strengthRepository)
        {
            _strengthRepository = strengthRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateStrengthCommand command, CancellationToken cancellationToken)
        {
            return await _strengthRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
