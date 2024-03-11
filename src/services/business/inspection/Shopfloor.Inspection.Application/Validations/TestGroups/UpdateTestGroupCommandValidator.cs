using FluentValidation;
using Shopfloor.Inspection.Application.Command.TestGroups;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.TestGroups
{
    public class UpdateTestGroupCommandValidator : AbstractValidator<UpdateTestGroupCommand>
    {
        private readonly ITestGroupRepository _repository;
        public UpdateTestGroupCommandValidator(ITestGroupRepository repository)
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
            RuleFor(p => p.Buyer).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.Category).NotEmpty().WithMessage("{PropertyName}  is required.").MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
			RuleFor(p => p.Description).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.GroupType).IsInEnum().WithMessage("{PropertyName} must be Enum .");
        }
        private async Task<bool> IsUniqueAsync(UpdateTestGroupCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
