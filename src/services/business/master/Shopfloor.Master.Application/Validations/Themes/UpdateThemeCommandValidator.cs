using FluentValidation;
using Shopfloor.Master.Application.Command.SupplierTypes;
using Shopfloor.Master.Application.Command.Themes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Themes
{
    public class UpdateThemeCommandValidator : AbstractValidator<UpdateThemeCommand>
    {
        private readonly IThemeRepository _themeRepository;
        public UpdateThemeCommandValidator(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateThemeCommand command, CancellationToken cancellationToken)
        {
            return await _themeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
