using FluentValidation;
using Shopfloor.Master.Application.Command.Departments;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Departments
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        private readonly IDivisionRepository _divisionRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public CreateDepartmentCommandValidator(IDivisionRepository divisionRepository, IDepartmentRepository departmentRepository)
        {
            _divisionRepository = divisionRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DivisionId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistDivision);
            _departmentRepository = departmentRepository;
        }
        private async Task<bool> IsExistDivision(int id, CancellationToken cancellationToken)
        {
            return await _divisionRepository.GetByIdAsync(id) != null;
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _departmentRepository.IsUniqueAsync(code);
        }
    }
}
