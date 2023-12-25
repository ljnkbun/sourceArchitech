using FluentValidation;
using Shopfloor.Master.Application.Command.SubOperationLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SubOperationLibraries
{
    public class CreateSubOperationLibraryCommandValidator : AbstractValidator<CreateSubOperationLibraryCommand>
    {
        private readonly ISubOperationLibraryRepository _subOperationLibraryRepository;
        private readonly IOperationLibraryRepository _operationLibraryRepository;
        public CreateSubOperationLibraryCommandValidator(ISubOperationLibraryRepository subOperationLibraryRepository, IOperationLibraryRepository operationLibraryRepository)
        {
            _operationLibraryRepository = operationLibraryRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.OperationLibraryId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistOperationLibrary);

            _subOperationLibraryRepository = subOperationLibraryRepository;
        }
    
        private async Task<bool> IsExistOperationLibrary(int id, CancellationToken cancellationToken)
        {
            return await _operationLibraryRepository.GetByIdAsync(id) != null;
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _subOperationLibraryRepository.IsUniqueAsync(code);
        }
    }
}
