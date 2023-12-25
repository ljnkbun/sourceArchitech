using FluentValidation;
using Shopfloor.Master.Application.Command.SubCategoryGroups;
using Shopfloor.Master.Application.Command.SupplierTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SupplierTypes
{
    public class UpdateSupplierTypeCommandValidator : AbstractValidator<UpdateSupplierTypeCommand>
    {
        private readonly ISupplierTypeRepository _supplierTypeRepository;
        public UpdateSupplierTypeCommandValidator(ISupplierTypeRepository supplierTypeRepository)
        {
            _supplierTypeRepository = supplierTypeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateSupplierTypeCommand command, CancellationToken cancellationToken)
        {
            return await _supplierTypeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
