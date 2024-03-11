using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingBackgroundStyles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingBackgroundStyles
{
    public class UpdateWeavingBackgroundStyleCommandValidator : AbstractValidator<UpdateWeavingBackgroundStyleCommand>
    {
        private readonly IWeavingBackgroundStyleRepository _weavingBackgroundStyleRepository;
        public UpdateWeavingBackgroundStyleCommandValidator(IWeavingBackgroundStyleRepository weavingBackgroundStyleRepository)
        {
            _weavingBackgroundStyleRepository = weavingBackgroundStyleRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateWeavingBackgroundStyleCommand command, CancellationToken token)
        {
            return await _weavingBackgroundStyleRepository.IsNameUniqueAsync(command.Name, command.Id);
        }
    }
}
