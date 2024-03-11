using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingBorderStyles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingBorderStyles
{
    public class UpdateWeavingBorderStyleCommandValidator : AbstractValidator<UpdateWeavingBorderStyleCommand>
    {
        private readonly IWeavingBorderStyleRepository _weavingBorderStyleRepository;
        public UpdateWeavingBorderStyleCommandValidator(IWeavingBorderStyleRepository weavingBorderStyleRepository)
        {
            _weavingBorderStyleRepository = weavingBorderStyleRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }

        private async Task<bool> IsUniqueAsync(UpdateWeavingBorderStyleCommand command, CancellationToken token)
        {
            return await _weavingBorderStyleRepository.IsNameUniqueAsync(command.Name, command.Id);
        }
    }
}
