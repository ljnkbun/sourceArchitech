using FluentValidation;
using NPOI.POIFS.Properties;
using Shopfloor.IED.Application.Command.DyeingIEDs;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingIEDs
{
    public class CreateDyeingIEDCommandValidator : AbstractValidator<CreateDyeingIEDCommand>
    {
        private readonly IRequestArticleOutputRepository _requestArticleOutput;

        private readonly IRecipeRepository _recipe;

        private readonly IRequestTypeRepository _requestType;

        public CreateDyeingIEDCommandValidator(IRequestArticleOutputRepository requestArticleOutput, IRecipeRepository recipe, IRequestTypeRepository requestType)
        {
            _requestArticleOutput = requestArticleOutput;
            _recipe = recipe;
            _requestType = requestType;

            RuleFor(p => p.ArticleCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ProductGroup)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategory)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Color)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ColorRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RequestNo)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.RequestArticleOutputId)
                .MustAsync(IsExistRequestArticleOutputAsync)
                .WithMessage("{PropertyName} not found."); 

            RuleFor(p => p.RequestTypeId)
                .MustAsync(IsExistRequestTypeAsync)
                .WithMessage("{PropertyName} not found."); 
            
            RuleFor(p => p.RecipeId)
                .MustAsync(IsExistRecipeAsync)
                .WithMessage("{PropertyName} not found.");

            RuleForEach(p => p.DyeingRoutings).ChildRules(childDyeingRouting =>
            {
                childDyeingRouting.RuleFor(p => p.DyeingProcess)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childDyeingRouting.RuleFor(p => p.DyeingProcessCode)
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childDyeingRouting.RuleFor(p => p.DyeingOperationCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childDyeingRouting.RuleFor(p => p.DyeingOperation)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childDyeingRouting.RuleFor(p => p.MachineCode)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childDyeingRouting.RuleFor(p => p.MachineName)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            });
        }

        private async Task<bool> IsExistRequestArticleOutputAsync(int requestArticleOutputId, CancellationToken token)
        {
            return await _requestArticleOutput.IsExistAsync(requestArticleOutputId);
        }
        private async Task<bool> IsExistRecipeAsync(int? recipeId, CancellationToken token)
        {
            return recipeId != null && await _recipe.IsExistAsync(recipeId.Value);
        }
        private async Task<bool> IsExistRequestTypeAsync(int? requestTypeId, CancellationToken token)
        {
            return requestTypeId != null && await _requestType.IsExistAsync(requestTypeId.Value);
        }
    }
}