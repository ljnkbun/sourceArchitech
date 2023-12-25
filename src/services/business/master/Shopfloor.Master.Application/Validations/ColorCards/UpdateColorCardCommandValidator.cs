using FluentValidation;
using Shopfloor.Master.Application.Command.ColorCards;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ColorCards
{
    public class UpdateColorCardCommandValidator : AbstractValidator<UpdateColorCardCommand>
    {
        private readonly IColorCardRepository _colorCardRepository;
        public UpdateColorCardCommandValidator(IColorCardRepository colorCardRepository)
        {
            _colorCardRepository = colorCardRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateColorCardCommand command, CancellationToken cancellationToken)
        {
            return await _colorCardRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
