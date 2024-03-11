using FluentValidation;
using Shopfloor.IED.Application.Command.Shades;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Shades
{
    public class CreateShadeCommandValidator : AbstractValidator<CreateShadeCommand>
    {
        private readonly IShadeRepository _shadeRepository;
        public CreateShadeCommandValidator(IShadeRepository shadeRepository)
        {
            _shadeRepository = shadeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique."); ;
        }

        private async Task<bool> IsUniqueAsync(string name, CancellationToken token)
        {
            return await _shadeRepository.IsNameUniqueAsync(name);
        }
    }
}
