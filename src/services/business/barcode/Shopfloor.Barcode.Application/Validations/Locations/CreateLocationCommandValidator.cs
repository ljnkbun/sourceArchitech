using FluentValidation;
using Shopfloor.Barcode.Application.Command.Locations;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Validations.Locations
{
    public class CreateLocationCommandValidator : AbstractValidator<CreateLocationCommand>
    {
        private readonly ILocationRepository _repository;
        public CreateLocationCommandValidator(ILocationRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ParentLocationId)
                .GreaterThan(0).WithMessage("{PropertyName} is GreaterThan.");

            RuleFor(p => p.Barcode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueBarcodeAsync).WithMessage("{PropertyName} must unique.")
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.LevelLocation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .IsInEnum().WithMessage("Value is not part of the enum.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }

        private async Task<bool> IsUniqueBarcodeAsync(string barcode, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueBarcodeAsync(barcode);
        }
    }
}
