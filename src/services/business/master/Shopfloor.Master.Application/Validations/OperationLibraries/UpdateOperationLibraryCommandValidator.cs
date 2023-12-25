using FluentValidation;
using NPOI.SS.Formula.Functions;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Application.Command.OperationLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.OperationLibraries
{
    public class UpdateOperationLibraryCommandValidator : AbstractValidator<UpdateOperationLibraryCommand>
    {
        private readonly IOperationLibraryRepository _operationLibraryRepository;
        public UpdateOperationLibraryCommandValidator(IOperationLibraryRepository operationLibraryRepository)
        {
            _operationLibraryRepository = operationLibraryRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ProcessLibraryId)
                .NotNull()
                .WithMessage("{PropertyName} must not Null.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateOperationLibraryCommand command, CancellationToken token)
        {
            return await _operationLibraryRepository.IsUniqueAsync(command.Code,command.Id);
        }
    }
}
