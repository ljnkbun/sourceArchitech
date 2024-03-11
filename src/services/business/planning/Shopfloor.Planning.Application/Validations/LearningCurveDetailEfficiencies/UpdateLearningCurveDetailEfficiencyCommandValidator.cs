using FluentValidation;
using Shopfloor.Planning.Application.Command.LearningCurveDetailEfficiencies;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.LearningCurveDetailEfficiencies
{
    public class UpdateLearningCurveDetailEfficiencyCommandValidator : AbstractValidator<UpdateLearningCurveDetailEfficiencyCommand>
    {
        private readonly ILearningCurveDetailEfficiencyRepository _repository;
        public UpdateLearningCurveDetailEfficiencyCommandValidator(ILearningCurveDetailEfficiencyRepository repository)
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
        private async Task<bool> IsUniqueAsync(UpdateLearningCurveDetailEfficiencyCommand command, CancellationToken token)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
