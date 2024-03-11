using FluentValidation;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Master.Application.Command.Buyers;
using Shopfloor.Master.Domain.Interfaces;
using System.Threading;

namespace Shopfloor.Master.Application.Validations.Buyers
{
    public class UpdateBuyerCommandValidator : AbstractValidator<UpdateBuyerCommand>
    {
        private readonly IBuyerRepository _buyerRepository;
        public UpdateBuyerCommandValidator(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
            RuleFor(p => p.WFXBuyerId)
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

        private async Task<bool> IsUniqueAsync(UpdateBuyerCommand command, CancellationToken token)
        {
            return await _buyerRepository.IsUniqueAsync(command.WFXBuyerId, command.Id);
        }
    }
}
