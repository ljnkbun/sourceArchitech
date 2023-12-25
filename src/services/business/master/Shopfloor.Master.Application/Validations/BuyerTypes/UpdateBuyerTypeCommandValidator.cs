using FluentValidation;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Domain.Interfaces;
using System.Threading;

namespace Shopfloor.Master.Application.Validations.BuyerTypes
{
    public class UpdateBuyerTypeCommandValidator : AbstractValidator<UpdateBuyerTypeCommand>
    {
        private readonly IBuyerTypeRepository _buyerTypeRepository;
        public UpdateBuyerTypeCommandValidator(IBuyerTypeRepository buyerTypeRepository)
        {
            _buyerTypeRepository = buyerTypeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateBuyerTypeCommand command, CancellationToken token)
        {
            return await _buyerTypeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
