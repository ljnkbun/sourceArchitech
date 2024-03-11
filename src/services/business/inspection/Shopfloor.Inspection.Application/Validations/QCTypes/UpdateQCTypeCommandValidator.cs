using FluentValidation;
using Shopfloor.Inspection.Application.Command.QCTypes;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.QCTypes
{
    public class UpdateQCTypeCommandValidator : AbstractValidator<UpdateQCTypeCommand>
    {
        private readonly IQCTypeRepository _repository;
        public UpdateQCTypeCommandValidator(IQCTypeRepository repository)
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
            
        }
        private async Task<bool> IsUniqueAsync(UpdateQCTypeCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
