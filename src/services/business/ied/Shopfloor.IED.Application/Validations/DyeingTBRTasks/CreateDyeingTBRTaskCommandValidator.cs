using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRTasks;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRTasks
{
    public class CreateDyeingTBRTaskCommandValidator : AbstractValidator<CreateDyeingTBRTaskCommand>
    {
        private readonly IDyeingTBRecipeRepository _repositoryDyingMaterialColorVersion;

        public CreateDyeingTBRTaskCommandValidator(IDyeingTBRecipeRepository repositoryDyingMaterialColorVersion)
        {
            _repositoryDyingMaterialColorVersion = repositoryDyingMaterialColorVersion;

            RuleFor(p => p.DyeingProcessName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.DyeingOperationName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.MachineCode)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.MachineName)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.DyeingTBRecipeId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingTbRecipeId, CancellationToken token)
        {
            return await _repositoryDyingMaterialColorVersion.IsExistAsync(dyeingTbRecipeId);
        }
    }
}