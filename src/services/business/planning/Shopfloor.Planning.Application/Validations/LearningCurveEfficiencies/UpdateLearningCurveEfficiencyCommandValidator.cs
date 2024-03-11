using FluentValidation;
using Shopfloor.Planning.Application.Command.LearningCurveEfficiencies;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.LearningCurveEfficiencies
{
    public class UpdateLearningCurveEfficiencyCommandValidator : AbstractValidator<UpdateLearningCurveEfficiencyCommand>
    {
        private readonly ILearningCurveEfficiencyRepository _repository;
        public UpdateLearningCurveEfficiencyCommandValidator(ILearningCurveEfficiencyRepository repository)
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
            RuleFor(p => p.Description).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
        }
        private async Task<bool> IsUniqueAsync(UpdateLearningCurveEfficiencyCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
