using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingBorderStyles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingBorderStyles
{
    public class CreateWeavingBorderStyleCommandValidator : AbstractValidator<CreateWeavingBorderStyleCommand>
    {
        private readonly IWeavingBorderStyleRepository _weavingBorderStyleRepository;
        public CreateWeavingBorderStyleCommandValidator(IWeavingBorderStyleRepository weavingBorderStyleRepository)
        {
            _weavingBorderStyleRepository = weavingBorderStyleRepository;
            
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
        }

        private async Task<bool> IsUniqueAsync(string name, CancellationToken token)
        {
            return await _weavingBorderStyleRepository.IsNameUniqueAsync(name);
        }
    }
}
