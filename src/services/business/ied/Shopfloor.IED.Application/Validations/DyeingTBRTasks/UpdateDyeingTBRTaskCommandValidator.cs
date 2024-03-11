using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRTasks
{
    public class UpdateDyeingTBRTaskCommandValidator : AbstractValidator<UpdateDyeingTBRTaskCommand>
    {
        private readonly IDyeingTBRecipeRepository _dyeingTbRecipe;
        private readonly IDyeingTBRTaskRepository _dyeingTbrTask;
        private readonly IDyeingTBRChemicalRepository _dyeingTbrChemical;

        public UpdateDyeingTBRTaskCommandValidator(IDyeingTBRecipeRepository dyeingTbRecipe, IDyeingTBRTaskRepository dyeingTbrTask, IDyeingTBRChemicalRepository dyeingTbrChemical)
        {
            _dyeingTbRecipe = dyeingTbRecipe;
            _dyeingTbrTask = dyeingTbrTask;
            _dyeingTbrChemical = dyeingTbrChemical;

            RuleFor(p => p.DyeingProcessName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.DyeingOperationName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.MachineCode)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MachineName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.DyeingTBRecipeId)
                .MustAsync(IsExistDyeingTBRecipeAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");

            RuleForEach(p => p.DyeingTBRChemicals).ChildRules(childDyeingTBRChemical =>
            {
                childDyeingTBRChemical.RuleFor(p => p.Unit)
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                childDyeingTBRChemical.RuleFor(p => p.ChemicalCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childDyeingTBRChemical.RuleFor(p => p.ChemicalName)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
                childDyeingTBRChemical.RuleFor(p => p.ChemicalSubCategory)
                    .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                childDyeingTBRChemical.RuleFor(p => p.DyeingTBRTaskId)
                    .MustAsync(IsExistDyeingTBRTaskAsync)
                    .WithMessage("{PropertyName} not found.");

                childDyeingTBRChemical.RuleForEach(p => p.DyeingTBRChemicalValues).ChildRules(childDyeingTBRChemicalValue =>
                {
                    childDyeingTBRChemicalValue.RuleFor(p => p.DyeingTBRChemicalId)
                        .MustAsync(IsExistDyeingTBRChemicalAsync)
                        .WithMessage("{PropertyName} not found.");
                });
            });
        }

        private async Task<bool> IsExistDyeingTBRecipeAsync(int dyeingTBRecipeId, CancellationToken token)
        {
            return await _dyeingTbRecipe.IsExistAsync(dyeingTBRecipeId);
        }

        private async Task<bool> IsExistDyeingTBRTaskAsync(int dyeingTBRTaskId, CancellationToken token)
        {
            if (dyeingTBRTaskId == 0)
            {
                return true;
            }
            return await _dyeingTbrTask.IsExistAsync(dyeingTBRTaskId);
        }

        private async Task<bool> IsExistDyeingTBRChemicalAsync(int dyeingTBRChemical, CancellationToken token)
        {
            if (dyeingTBRChemical == 0)
            {
                return true;
            }
            return await _dyeingTbrChemical.IsExistAsync(dyeingTBRChemical);
        }
    }
}