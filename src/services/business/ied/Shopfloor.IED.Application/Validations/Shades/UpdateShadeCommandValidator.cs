using FluentValidation;
using Shopfloor.IED.Application.Command.Shades;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Shades
{
    public class UpdateShadeCommandValidator : AbstractValidator<UpdateShadeCommand>
    {
        private readonly IShadeRepository _shadeRepository;
        public UpdateShadeCommandValidator(IShadeRepository shadeRepository)
        {
            _shadeRepository = shadeRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateShadeCommand command, CancellationToken token)
        {
            return await _shadeRepository.IsNameUniqueAsync(command.Name, command.Id);
        }
    }
}
