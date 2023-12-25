using FluentValidation;
using Shopfloor.Master.Application.Command.Grades;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Grades
{
    public class CreateGradeCommandValidator : AbstractValidator<CreateGradeCommand>
    {
        private readonly IGradeRepository _gradeRepository;
        public CreateGradeCommandValidator(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
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
            return await _gradeRepository.IsUniqueAsync(code);
        }
    }
}
