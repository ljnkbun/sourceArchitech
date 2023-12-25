using FluentValidation;
using Shopfloor.Master.Application.Command.Strengths;
using Shopfloor.Master.Application.Command.MachineTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.MachineTypes
{
    public class UpdateMachineTypeCommandValidator : AbstractValidator<UpdateMachineTypeCommand>
    {
        private readonly IMachineTypeRepository _structureRepository;
        public UpdateMachineTypeCommandValidator(IMachineTypeRepository structureRepository)
        {
            _structureRepository = structureRepository;
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

        private async Task<bool> IsUniqueAsync(UpdateMachineTypeCommand command, CancellationToken cancellationToken)
        {
            return await _structureRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
