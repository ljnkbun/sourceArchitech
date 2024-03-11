using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRecipes;
using Shopfloor.IED.Application.Command.Recipes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRecipes
{
    public class CreateDyeingTBRecipeCommandValidator : AbstractValidator<CreateDyeingTBRecipeCommand>
    {
        private readonly IDyeingTBMaterialColorRepository _dyeingTbMaterialColor;

        public CreateDyeingTBRecipeCommandValidator(IDyeingTBMaterialColorRepository dyeingTbMaterialColor)
        {
            _dyeingTbMaterialColor = dyeingTbMaterialColor;

            RuleFor(p => p.TemplateName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.TBRecipeName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.TCFNo)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Comment)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.BuyerRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.GarmentStyleRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Color)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Concentration)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.VersionQty)
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 0.");

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.DyeingTBMaterialColorId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");

            RuleForEach(p => p.DyeingTBRTasks).ChildRules(childDyeingTBRTask =>
             {
                 childDyeingTBRTask.RuleFor(p => p.DyeingProcessName)
                     .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

                 childDyeingTBRTask.RuleFor(p => p.DyeingOperationName)
                     .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

                 childDyeingTBRTask.RuleFor(p => p.MachineCode)
                     .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                 childDyeingTBRTask.RuleFor(p => p.MachineName)
                     .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

                 childDyeingTBRTask.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");

                 childDyeingTBRTask.RuleForEach(p => p.DyeingTBRChemicals).ChildRules(childDyeingTBRChemical =>
                 {
                     childDyeingTBRChemical.RuleFor(p => p.Unit)
                         .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                     childDyeingTBRChemical.RuleFor(p => p.ChemicalCode)
                         .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                     childDyeingTBRChemical.RuleFor(p => p.ChemicalName)
                         .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                     childDyeingTBRChemical.RuleFor(p => p.ChemicalSubCategory)
                         .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                 });
             });
        }

        private async Task<bool> IsExistAsync(int dyeingTbMaterialColorId, CancellationToken token)
        {
            return await _dyeingTbMaterialColor.IsExistAsync(dyeingTbMaterialColorId);
        }
        private bool IsLineNumberUnique(CreateDyeingTBRecipeCommand command)
        {
            return command.DyeingTBRTasks.DistinctBy(m => m.LineNumber).Count() == command.DyeingTBRTasks.Count;
        }
    }
}