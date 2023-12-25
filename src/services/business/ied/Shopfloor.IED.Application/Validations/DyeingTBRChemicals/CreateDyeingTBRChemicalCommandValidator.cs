using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRChemicals
{
    public class CreateDyeingTBRChemicalCommandValidator : AbstractValidator<CreateDyeingTBRChemicalCommand>
    {
        private readonly IDyeingTBRTaskRepository _dyeingTBRTask;

        public CreateDyeingTBRChemicalCommandValidator(IDyeingTBRTaskRepository dyeingTBRTask)
        {
            _dyeingTBRTask = dyeingTBRTask;

            RuleFor(p => p.Unit)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ChemicalCode)
                .MaximumLength(20).WithMessage("{PropertyName} must not exceed 20 characters.");

            RuleFor(p => p.ChemicalName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DyeingTBRTaskId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingTbrTaskId, CancellationToken token)
        {
            return await _dyeingTBRTask.IsExistAsync(dyeingTbrTaskId);
        }
    }
}