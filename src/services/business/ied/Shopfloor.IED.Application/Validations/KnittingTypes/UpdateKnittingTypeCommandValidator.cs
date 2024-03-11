using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingTypes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingTypes
{
    public class UpdateKnittingTypeCommandValidator : AbstractValidator<UpdateKnittingTypeCommand>
    {
        private readonly IKnittingTypeRepository _repository;
        public UpdateKnittingTypeCommandValidator(IKnittingTypeRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }
        private async Task<bool> IsUniqueAsync(UpdateKnittingTypeCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Name, command.Id);
        }
    }
}
