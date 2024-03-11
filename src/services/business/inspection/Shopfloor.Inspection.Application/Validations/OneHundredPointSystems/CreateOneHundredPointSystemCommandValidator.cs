using FluentValidation;
using Shopfloor.Inspection.Application.Command.OneHundredPointSystems;
using Shopfloor.Inspection.Domain.Interfaces;

namespace Shopfloor.Inspection.Application.Validations.OneHundredPointSystems
{
    public class CreateOneHundredPointSystemCommandValidator : AbstractValidator<CreateOneHundredPointSystemCommand>
    {
        IOneHundredPointSystemRepository _repository;
        public CreateOneHundredPointSystemCommandValidator(IOneHundredPointSystemRepository repository)
        {
            _repository = repository;
            
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
            return await _repository.IsUniqueAsync(code);
        }
    }
}
