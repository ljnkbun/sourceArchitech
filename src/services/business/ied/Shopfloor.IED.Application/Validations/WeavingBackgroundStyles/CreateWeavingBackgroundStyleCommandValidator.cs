using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingBackgroundStyles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingBackgroundStyles
{
    public class CreateWeavingBackgroundStyleCommandValidator : AbstractValidator<CreateWeavingBackgroundStyleCommand>
    {
        private readonly IWeavingBackgroundStyleRepository _weavingBackgroundStyleRepository;
        public CreateWeavingBackgroundStyleCommandValidator(IWeavingBackgroundStyleRepository weavingBackgroundStyleRepository)
        {
            _weavingBackgroundStyleRepository = weavingBackgroundStyleRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
        }

        private async Task<bool> IsUniqueAsync(string name, CancellationToken token)
        {
            return await _weavingBackgroundStyleRepository.IsNameUniqueAsync(name);
        }
    }
}
