using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRCValues;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRCValues
{
    public class CreateDyeingTBRCValueCommandValidator : AbstractValidator<CreateDyeingTBRCValueCommand>
    {
        private readonly IDyeingTBRChemicalRepository _dyeingTbrChemical;

        private readonly IDyeingTBRVersionRepository _dyeingTbrVersion;

        public CreateDyeingTBRCValueCommandValidator(IDyeingTBRChemicalRepository dyeingTbrChemical, IDyeingTBRVersionRepository dyeingTbrVersion)
        {
            _dyeingTbrChemical = dyeingTbrChemical;
            _dyeingTbrVersion = dyeingTbrVersion;

            RuleFor(p => p.DyeingTBRChemicalId)
                .MustAsync(IsExistDyeingTBRChemicalAsync)
                .WithMessage("{PropertyName} not found.");

            RuleFor(p => p.DyeingTBRVersionId)
                .MustAsync(IsExistDyeingTBRVersionAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistDyeingTBRChemicalAsync(int dyeingTbrChemicalId, CancellationToken token)
        {
            return await _dyeingTbrChemical.IsExistAsync(dyeingTbrChemicalId);
        }

        private async Task<bool> IsExistDyeingTBRVersionAsync(int dyeingTbrVersionId, CancellationToken token)
        {
            return await _dyeingTbrVersion.IsExistAsync(dyeingTbrVersionId);
        }
    }
}