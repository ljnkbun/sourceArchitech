using FluentValidation;
using NPOI.SS.Formula.Functions;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Application.Command.SubOperationLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SubOperationLibraries
{
    public class UpdateSubOperationLibraryCommandValidator : AbstractValidator<UpdateSubOperationLibraryCommand>
    {
        private readonly ISubOperationLibraryRepository _subOperationLibraryRepository;
        public UpdateSubOperationLibraryCommandValidator(ISubOperationLibraryRepository subOperationLibraryRepository)
        {
            _subOperationLibraryRepository = subOperationLibraryRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.OperationLibraryId)
                .NotNull()
                .WithMessage("{PropertyName} must not Null.");
            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateSubOperationLibraryCommand command, CancellationToken token)
        {
            return await _subOperationLibraryRepository.IsUniqueAsync(command.Code,command.Id);
        }
    }
}
