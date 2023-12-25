using FluentValidation;
using Shopfloor.Master.Application.Command.Departments;
using Shopfloor.Master.Application.Command.Divisions;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Divisions
{
    public class UpdateDivisionCommandValidator : AbstractValidator<UpdateDivisionCommand>
    {
        private readonly IDivisionRepository _divisionRepository;
        public UpdateDivisionCommandValidator(IDivisionRepository divisionRepository)
        {
            _divisionRepository = divisionRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateDivisionCommand command, CancellationToken cancellationToken)
        {
            return await _divisionRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
