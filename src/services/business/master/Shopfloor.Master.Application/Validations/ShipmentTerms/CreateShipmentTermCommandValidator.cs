using FluentValidation;
using Shopfloor.Master.Application.Command.ShipmentTerms;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ShipmentTerms
{
    public class CreateShipmentTermCommandValidator : AbstractValidator<CreateShipmentTermCommand>
    {
        private readonly IShipmentTermRepository _shipmentTermRepository;
        public CreateShipmentTermCommandValidator(IShipmentTermRepository shipmentTermRepository)
        {

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            _shipmentTermRepository = shipmentTermRepository;
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _shipmentTermRepository.IsUniqueAsync(code);
        }
    }
}
