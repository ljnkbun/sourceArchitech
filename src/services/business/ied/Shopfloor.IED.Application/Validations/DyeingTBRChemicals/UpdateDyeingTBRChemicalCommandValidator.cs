using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRChemicals
{
    public class UpdateDyeingTBRChemicalCommandValidator : AbstractValidator<UpdateDyeingTBRChemicalCommand>
    {
        private readonly IDyeingTBRTaskRepository _dyeingTbrTask;
        private readonly IDyeingTBRChemicalRepository _dyeingTbrChemical;

        public UpdateDyeingTBRChemicalCommandValidator(IDyeingTBRTaskRepository dyeingTbrTask, IDyeingTBRChemicalRepository dyeingTbrChemical)
        {
            _dyeingTbrTask = dyeingTbrTask;
            _dyeingTbrChemical = dyeingTbrChemical;

            RuleFor(p => p.Unit)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ChemicalCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ChemicalName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
            RuleFor(p => p.ChemicalSubCategory)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
            RuleFor(p => p.DyeingTBRTaskId)
                .MustAsync(IsExistDyeingTBRTaskAsync)
                .WithMessage("{PropertyName} not found.");

            RuleForEach(p => p.DyeingTBRChemicalValues).ChildRules(childDyeingTBRChemicalValue =>
            {
                childDyeingTBRChemicalValue.RuleFor(p => p.DyeingTBRChemicalId)
                    .MustAsync(IsExistDyeingTBRChemicalAsync)
                    .WithMessage("{PropertyName} not found.");
            });
        }

        private async Task<bool> IsExistDyeingTBRTaskAsync(int dyeingTBRTaskId, CancellationToken token)
        {
            return await _dyeingTbrTask.IsExistAsync(dyeingTBRTaskId);
        }

        private async Task<bool> IsExistDyeingTBRChemicalAsync(int dyeingTBRChemical, CancellationToken token)
        {
            return await _dyeingTbrChemical.IsExistAsync(dyeingTBRChemical);
        }
    }
}