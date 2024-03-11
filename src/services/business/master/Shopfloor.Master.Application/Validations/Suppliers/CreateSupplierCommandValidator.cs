using FluentValidation;
using Shopfloor.Master.Application.Command.Suppliers;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Suppliers
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;
        public CreateSupplierCommandValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
            RuleFor(p => p.WFXSupplierId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string WFXSupplierId, CancellationToken cancellationToken)
        {
            return await _supplierRepository.IsUniqueAsync(WFXSupplierId);
        }
    }
}
