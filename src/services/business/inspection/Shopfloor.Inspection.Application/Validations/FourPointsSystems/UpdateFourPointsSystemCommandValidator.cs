using FluentValidation;
using Shopfloor.Inspection.Application.Command.FourPointsSystems;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.FourPointsSystems
{
    public class UpdateFourPointsSystemCommandValidator : AbstractValidator<UpdateFourPointsSystemCommand>
    {
        private readonly IFourPointsSystemRepository _repository;
        public UpdateFourPointsSystemCommandValidator(IFourPointsSystemRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
            RuleFor(p => p.ProductGroup).MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
        private async Task<bool> IsUniqueAsync(UpdateFourPointsSystemCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
