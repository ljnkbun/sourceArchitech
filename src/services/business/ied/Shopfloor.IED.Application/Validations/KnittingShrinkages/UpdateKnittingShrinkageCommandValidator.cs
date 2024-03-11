using FluentValidation;
using Shopfloor.IED.Application.Command.KnittingShrinkages;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.KnittingShrinkages
{
    public class UpdateKnittingShrinkageCommandValidator : AbstractValidator<UpdateKnittingShrinkageCommand>
    {
        private readonly IKnittingShrinkageRepository _repository;
        public UpdateKnittingShrinkageCommandValidator(IKnittingShrinkageRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Name must unique.");
        }
        private async Task<bool> IsUniqueAsync(UpdateKnittingShrinkageCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Name, command.Id);
        }
    }
}
