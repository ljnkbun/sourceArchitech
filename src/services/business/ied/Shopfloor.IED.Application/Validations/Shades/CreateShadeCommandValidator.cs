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
            return await _shadeRepository.IsUniqueAsync(code);
        }
    }
}
