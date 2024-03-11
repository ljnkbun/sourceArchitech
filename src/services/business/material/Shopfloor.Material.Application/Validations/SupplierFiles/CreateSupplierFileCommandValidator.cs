using FluentValidation;
using Shopfloor.Material.Application.Command.SupplierFiles;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Validations.SupplierFiles
{
    public class CreateSupplierFileCommandValidator : AbstractValidator<CreateSupplierFileCommand>
    {
        private readonly ISupplierRepository _supplier;

        public CreateSupplierFileCommandValidator(ISupplierRepository supplier)
        {
            _supplier = supplier;
            RuleFor(p => p.FileId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.FileName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SupplierId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int SupplierId, CancellationToken token)
        {
            return await _supplier.IsExistAsync(SupplierId);
        }
    }
}