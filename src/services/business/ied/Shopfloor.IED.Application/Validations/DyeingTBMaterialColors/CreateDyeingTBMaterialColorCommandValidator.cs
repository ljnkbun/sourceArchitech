using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBMaterialColors;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBMaterialColors
{
    public class CreateDyeingTBMaterialColorCommandValidator : AbstractValidator<CreateDyeingTBMaterialColorCommand>
    {
        private readonly IDyeingTBMaterialRepository _dyeingTbMaterialRepository;

        public CreateDyeingTBMaterialColorCommandValidator(IDyeingTBMaterialRepository dyeingTbMaterialRepository)
        {
            _dyeingTbMaterialRepository = dyeingTbMaterialRepository;

            RuleFor(p => p.Color)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Pantone)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Status)
                .IsInEnum().WithMessage("Value is not part of the enum.");

            RuleFor(p => p.DyeingTBMaterialId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingTbMaterialId, CancellationToken token)
        {
            return await _dyeingTbMaterialRepository.IsExistAsync(dyeingTbMaterialId);
        }
    }
}