using FluentValidation;
using Shopfloor.Master.Application.Command.ProcessLibraries;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ProcessLibraries
{
    public class CreateProcessLibraryCommandValidator : AbstractValidator<CreateProcessLibraryCommand>
    {
        private readonly IProcessLibraryRepository _processLibraryRepository;
        public CreateProcessLibraryCommandValidator(IProcessLibraryRepository processLibraryRepository)
        {
            _processLibraryRepository = processLibraryRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _processLibraryRepository.IsUniqueAsync(code);
        }
    }
}
