using FluentValidation;
using Shopfloor.IED.Application.Command.Recipes;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.Recipes
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        private readonly IDyeingTBRequestRepository _dyeingTbRequest;

        private readonly IDyeingTBRVersionRepository _dyeingTbrVersion;

        public CreateRecipeCommandValidator(IDyeingTBRequestRepository dyeingTbRequest, IDyeingTBRVersionRepository dyeingTbrVersion)
        {
            _dyeingTbRequest = dyeingTbRequest;
            _dyeingTbrVersion = dyeingTbrVersion;

            RuleFor(p => p.TCFNO)
             .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Style)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.FabricCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.FabricName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Color)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.LotNo)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RollKg)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Speed)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.NozzleA)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.NozzleB)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Method)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.LAB)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.InCharge)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Manager)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingTBRequestId)
                .MustAsync(IsExistDyeingTBRequestAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.DyeingTBRVersionId)
                .MustAsync(IsExistDyeingTBRVersionAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistDyeingTBRequestAsync(int dyeingTbRequestId, CancellationToken token)
        {
            return await _dyeingTbRequest.IsExistAsync(dyeingTbRequestId);
        }

        private async Task<bool> IsExistDyeingTBRVersionAsync(int dyeingTBRVersionId, CancellationToken token)
        {
            return await _dyeingTbrVersion.IsExistAsync(dyeingTBRVersionId);
        }
    }
}