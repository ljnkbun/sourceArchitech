using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingMachineDiameters;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingMachineDiameters
{
    public class UpdateKnittingMachineDiameterCommandValidator : AbstractValidator<UpdateKnittingMachineDiameterCommand>
    {
        private readonly IKnittingMachineDiameterRepository _repository;
        public UpdateKnittingMachineDiameterCommandValidator(IKnittingMachineDiameterRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }
        private async Task<bool> IsUniqueAsync(UpdateKnittingMachineDiameterCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Name, command.Id);
        }
    }
}
