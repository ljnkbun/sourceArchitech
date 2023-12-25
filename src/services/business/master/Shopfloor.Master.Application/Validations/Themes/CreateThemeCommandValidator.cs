using FluentValidation;
using Shopfloor.Master.Application.Command.Themes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Themes
{
    public class CreateThemeCommandValidator : AbstractValidator<CreateThemeCommand>
    {
        private readonly IThemeRepository _themeRepository;
        public CreateThemeCommandValidator(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
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
            return await _themeRepository.IsUniqueAsync(code);
        }
    }
}
