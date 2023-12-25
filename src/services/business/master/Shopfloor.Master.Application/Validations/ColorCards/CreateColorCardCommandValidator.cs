using FluentValidation;
using Shopfloor.Master.Application.Parameters.ColorCards;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ColorCards
{
    public class CreateColorCardCommandValidator : AbstractValidator<ColorCardParameter>
    {
        private readonly IColorCardRepository _colorCardRepository;
        public CreateColorCardCommandValidator(IColorCardRepository colorCardRepository)
        {
            _colorCardRepository = colorCardRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.GroupId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _colorCardRepository.IsUniqueAsync(code);
        }
    }
}
