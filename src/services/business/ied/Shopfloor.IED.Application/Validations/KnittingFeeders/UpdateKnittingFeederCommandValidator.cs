using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingFeeders;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingFeeders
{
    public class UpdateKnittingFeederCommandValidator : AbstractValidator<UpdateKnittingFeederCommand>
    {
        private readonly IKnittingFeederRepository _repository;
        public UpdateKnittingFeederCommandValidator(IKnittingFeederRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }
        private async Task<bool> IsUniqueAsync(UpdateKnittingFeederCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Name, command.Id);
        }
    }
}
