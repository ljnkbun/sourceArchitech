using FluentValidation;
using Shopfloor.Barcode.Application.Command.Locations;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Locations
{
    public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
    {
        private readonly ILocationRepository _repository;
        public UpdateLocationCommandValidator(ILocationRepository repository)
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

            RuleFor(p => p.ParentLocationId)
                .GreaterThan(0).WithMessage("{PropertyName} is GreaterThan.");

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.LevelLocation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("Code must unique.")
                .MustAsync(IsUniqueBarcodeAsync).WithMessage("Barcode must unique.");
            #endregion
        }
        private async Task<bool> IsUniqueAsync(UpdateLocationCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }

        private async Task<bool> IsUniqueBarcodeAsync(UpdateLocationCommand command, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueBarcodeAsync(command.Barcode);
        }
    }
}
