using FluentValidation;
using Shopfloor.Planning.Application.Command.PORDetails;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.WfxPORProperties
{
    public class UpdatePORDetailCommandValidator : AbstractValidator<UpdatePORDetailCommand>
    {
        private readonly IPORRepository _repository;
        public UpdatePORDetailCommandValidator(IPORRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Color)
                .NotNull()
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Size)
                .NotNull()
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.OrderedQuantity)
               .NotNull()
               .WithMessage("{PropertyName} must not null.");

            RuleFor(p => p.RemainingQuantity)
               .NotNull()
               .WithMessage("{PropertyName} must not null.");

            RuleFor(p => p.PORId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistPOR);

            RuleFor(p => p.Type)
                .NotNull()
                .IsInEnum()
                .WithMessage("Value is not part of the enum.");
        }
        private async Task<bool> IsExistPOR(int id, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(id) != null;
        }
    }
}
