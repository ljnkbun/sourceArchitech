using FluentValidation;
using NPOI.SS.Formula.Functions;
using Shopfloor.Master.Application.Command.BuyerTypes;
using Shopfloor.Master.Application.Command.ProcessLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ProcessLibraries
{
    public class UpdateProcessLibraryCommandValidator : AbstractValidator<UpdateProcessLibraryCommand>
    {
        private readonly IProcessLibraryRepository _processLibraryRepository;
        public UpdateProcessLibraryCommandValidator(IProcessLibraryRepository processLibraryRepository)
        {
            _processLibraryRepository = processLibraryRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateProcessLibraryCommand command, CancellationToken token)
        {
            return await _processLibraryRepository.IsUniqueAsync(command.Code,command.Id);
        }
    }
}
