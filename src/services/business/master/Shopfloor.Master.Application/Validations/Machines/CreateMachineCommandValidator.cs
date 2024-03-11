using FluentValidation;
using Shopfloor.Master.Application.Command.Machines;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.Machines
{
    public class CreateMachineCommandValidator : AbstractValidator<CreateMachineCommand>
    {
        private readonly IMachineRepository _structureRepository;
        public CreateMachineCommandValidator(IMachineRepository structureRepository)
        {
            _structureRepository = structureRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SerialNo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(r => r.Capacity).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.FactoryId).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
            RuleFor(r => r.ProcessId).NotNull().GreaterThan(0).WithMessage("{PropertyName}  is required.");
        }

        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _structureRepository.IsUniqueAsync(code);
        }
    }
}
