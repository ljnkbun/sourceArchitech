using FluentValidation;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Application.Command.ShipmentTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ShipmentTerms
{
    public class UpdateShipmentTermCommandValidator : AbstractValidator<UpdateShipmentTermCommand>
    {
        private readonly IShipmentTermRepository _shipmentTermRepository;
        public UpdateShipmentTermCommandValidator(IShipmentTermRepository shipmentTermRepository)
        {
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            _shipmentTermRepository = shipmentTermRepository;

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateShipmentTermCommand command, CancellationToken cancellationToken)
        {
            return await _shipmentTermRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
