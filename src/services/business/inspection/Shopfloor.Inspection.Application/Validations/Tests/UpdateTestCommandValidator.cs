using FluentValidation;
using Shopfloor.Inspection.Application.Command.Tests;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.Tests
{
    public class UpdateTestCommandValidator : AbstractValidator<UpdateTestCommand>
    {
        private readonly ITestRepository _repository;
        public UpdateTestCommandValidator(ITestRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
            RuleFor(p => p.Description).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(r => r.TestGroupId).GreaterThan(0).WithMessage("{PropertyName}  is required.");

        }
        private async Task<bool> IsUniqueAsync(UpdateTestCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
