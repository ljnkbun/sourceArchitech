using FluentValidation;
using Shopfloor.Master.Application.Command.DeliveryTerms;
using Shopfloor.Master.Application.Command.Departments;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Departments
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public UpdateDepartmentCommandValidator(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DivisionId)
                .NotNull()
                .WithMessage("{PropertyName} must not Null.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            return await _departmentRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
