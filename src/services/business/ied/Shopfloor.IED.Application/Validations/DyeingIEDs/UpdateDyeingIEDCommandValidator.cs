using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingIEDs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingIEDs
{
    public class UpdateDyeingIEDCommandValidator : AbstractValidator<UpdateDyeingIEDCommand>
    {
        private readonly IDyeingIEDRepository _dyeingIed;

        private readonly IRecipeRepository _recipe;

        public UpdateDyeingIEDCommandValidator(IDyeingIEDRepository dyeingIed, IRecipeRepository recipe)
        {
            _dyeingIed = dyeingIed;
            _recipe = recipe;

            RuleFor(p => p.ArticleCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            
            RuleFor(p => p.RecipeId)
                .MustAsync(IsExistRecipeAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p).Must(IsLineNumberUnique).WithMessage("LineNumber must unique.");

            RuleForEach(x => x.DyeingRoutings).ChildRules(child =>
            {
                child.RuleFor(p => p.DyeingProcess)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.DyeingProcessCode)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.DyeingOperation)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.MachineCode)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.DyeingOperationCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.MachineName)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.DyeingIEDId)
                    .MustAsync(IsExistAsync)
                    .WithMessage("{PropertyName} not found.");

                child.RuleFor(p => p).Must(p => p.LineNumber >= 1).WithMessage("LineNumber must greater than or equal 1.");
            });
        }
        private async Task<bool> IsExistRecipeAsync(int? recipeId, CancellationToken token)
        {
            return recipeId != null && await _recipe.IsExistAsync(recipeId.Value);
        }
        private async Task<bool> IsExistAsync(int dyeingIEDId, CancellationToken token)
        {
            return await _dyeingIed.IsExistAsync(dyeingIEDId);
        }
        private bool IsLineNumberUnique(UpdateDyeingIEDCommand command)
        {
            return command?.DyeingRoutings.DistinctBy(m => m.LineNumber).Count() == command?.DyeingRoutings.Count;
        }
    }
}