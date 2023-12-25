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

        private async Task<bool> IsUniqueAsync(string code, CancellationToken token)
        {
            return await _weavingBorderStyleRepository.IsUniqueAsync(code);
        }
    }
}
