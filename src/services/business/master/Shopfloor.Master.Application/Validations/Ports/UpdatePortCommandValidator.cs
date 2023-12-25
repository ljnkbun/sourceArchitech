using FluentValidation;
using Shopfloor.Master.Application.Command.PaymentTerms;
using Shopfloor.Master.Application.Command.Ports;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Ports
{
    public class UpdatePortCommandValidator : AbstractValidator<UpdatePortCommand>
    {
        private readonly IPortRepository _portRepository;
        public UpdatePortCommandValidator(IPortRepository portRepository)
        {
            _portRepository = portRepository;
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

        private async Task<bool> IsUniqueAsync(UpdatePortCommand command, CancellationToken cancellationToken)
        {
            return await _portRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
