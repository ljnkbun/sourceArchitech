using FluentValidation;
using Shopfloor.Master.Application.Command.Genders;
using Shopfloor.Master.Application.Command.Grades;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Grades
{
    public class UpdateGradeCommandValidator : AbstractValidator<UpdateGradeCommand>
    {
        private readonly IGradeRepository _gradeRepository;
        public UpdateGradeCommandValidator(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository; 
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateGradeCommand command, CancellationToken cancellationToken)
        {
            return await _gradeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
