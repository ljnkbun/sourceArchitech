using FluentValidation;
using Shopfloor.IED.Application.Command.SewingOperationLibs;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.SewingOperationLibs
{
    public class CreateSewingOperationLibCommandValidator : AbstractValidator<CreateSewingOperationLibCommand>
    {
        private readonly ISewingTaskLibRepository _repository;
        public CreateSewingOperationLibCommandValidator(ISewingTaskLibRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.SubCategoryCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.SubCategoryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");
            RuleFor(p => p).Must(IsValid).WithMessage("Data invalid.");
            RuleFor(p => p).MustAsync(IsLessThanTwoMachineTasksWithSameProfileAsync).WithMessage("Operation cannot have two machine Tasks with same Profile.");

            RuleForEach(x => x.SewingOperationLibBOLs).ChildRules(child =>
            {
                child.RuleFor(p => p.Code).MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                child.RuleFor(p => p.Name).MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
                child.RuleFor(p => p.Freq).MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                child.RuleFor(p => p.Type).IsInEnum().WithMessage("Type out of range.");
                child.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            });
        }
        private bool IsLineNumberUnique(CreateSewingOperationLibCommand command)
        {
            return command?.SewingOperationLibBOLs.DistinctBy(m => m.LineNumber).Count() == command?.SewingOperationLibBOLs.Count;
        }
        private bool IsValid(CreateSewingOperationLibCommand command)
        {
            return command?.SewingOperationLibBOLs.All(b => ((b.Type == OperationBOLType.CO || b.Type == OperationBOLType.MN || b.Type == OperationBOLType.BU) && b.SewingTaskLibId != null)
                                                         || (b.Type == OperationBOLType.MC && b.SewingMacroLibId != null)
                                                         || (b.Type == OperationBOLType.CM && b.SewingMacroLibId == null && b.SewingTaskLibId == null)) ?? true;
        }
        private async Task<bool> IsLessThanTwoMachineTasksWithSameProfileAsync(CreateSewingOperationLibCommand command, CancellationToken token)
        {
            var machineTaskIds = command.SewingOperationLibBOLs.Where(b => b.Type == OperationBOLType.MN).Select(b => b.SewingTaskLibId??0);
            if (machineTaskIds == null || machineTaskIds.Count() <= 1)
                return true;

            var machineTasks = await _repository.GetByIdsAsync(machineTaskIds.ToList());
            if (machineTasks == null)
                return true;

            return machineTasks.DistinctBy(t => t.SewingMachineEfficiencyProfile.SewingEfficiencyProfileId).Count() <= 1;
        }
    }
}
