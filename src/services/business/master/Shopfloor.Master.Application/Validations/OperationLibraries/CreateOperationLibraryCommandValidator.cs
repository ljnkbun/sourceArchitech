using FluentValidation;
using Shopfloor.Master.Application.Command.OperationLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.OperationLibraries
{
    public class CreateOperationLibraryCommandValidator : AbstractValidator<CreateOperationLibraryCommand>
    {
        private readonly IOperationLibraryRepository _operationLibraryRepository;
        private readonly IProcessRepository _ProcessRepository;
        public CreateOperationLibraryCommandValidator(IOperationLibraryRepository operationLibraryRepository, IProcessRepository ProcessRepository)
        {
            _ProcessRepository = ProcessRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.ProcessId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistProcess);

            _operationLibraryRepository = operationLibraryRepository;
        }
        private async Task<bool> IsExistProcess(int id, CancellationToken cancellationToken)
        {
            return await _ProcessRepository.GetByIdAsync(id) != null;
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _operationLibraryRepository.IsUniqueAsync(code);
        }
    }
}
