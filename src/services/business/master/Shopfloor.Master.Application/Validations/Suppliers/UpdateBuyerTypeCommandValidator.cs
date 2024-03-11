using FluentValidation;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Master.Application.Command.Suppliers;
using Shopfloor.Master.Domain.Interfaces;
using System.Threading;

namespace Shopfloor.Master.Application.Validations.Suppliers
{
    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        private readonly ISupplierRepository _supplierRepository;
        public UpdateSupplierCommandValidator(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
            RuleFor(p => p.WFXSupplierId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateSupplierCommand command, CancellationToken token)
        {
            return await _supplierRepository.IsUniqueAsync(command.WFXSupplierId, command.Id);
        }
    }
}
