using FluentValidation;
using Shopfloor.IED.Application.Command.LabourSkills;
using Shopfloor.IED.Application.Command.Zones;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.LabourSkills
{
    public class UpdateLabourSkillCommandValidator : AbstractValidator<UpdateLabourSkillCommand>
    {
        private readonly ILabourSkillRepository _labourSkillRepository;
        public UpdateLabourSkillCommandValidator(ILabourSkillRepository labourSkillRepository)
        {
            _labourSkillRepository = labourSkillRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p).MustAsync(IsUniqueAsync).WithMessage("Code must unique.");
        }
        private async Task<bool> IsUniqueAsync(UpdateLabourSkillCommand command, CancellationToken token)
        {
            return await _labourSkillRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
