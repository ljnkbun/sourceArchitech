using FluentValidation;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.LearningCurveEfficiencies
{
    public class CreateLearningCurveEfficiencyCommandValidator : AbstractValidator<CreateLearningCurveEfficiencyCommand>
    {
        ILearningCurveEfficiencyRepository _repository;
        public CreateLearningCurveEfficiencyCommandValidator(ILearningCurveEfficiencyRepository repository)
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
            RuleFor(p => p.Description).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(code);
        }
    }
}
