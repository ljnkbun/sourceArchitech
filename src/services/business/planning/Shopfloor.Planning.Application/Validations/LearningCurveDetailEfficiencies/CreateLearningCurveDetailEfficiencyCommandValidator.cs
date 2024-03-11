using FluentValidation;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.LearningCurveDetailEfficiencies
{
    public class CreateLearningCurveDetailEfficiencyCommandValidator : AbstractValidator<CreateLearningCurveDetailEfficiencyCommand>
    {
        ILearningCurveDetailEfficiencyRepository _repository;
        public CreateLearningCurveDetailEfficiencyCommandValidator(ILearningCurveDetailEfficiencyRepository repository)
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

            RuleFor(r => r.EfficiencyValue).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.Days).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
