using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRChemicalValues;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRChemicalValues
{
    public class UpdateDyeingTBRChemicalValueCommandValidator : AbstractValidator<UpdateDyeingTBRChemicalValueCommand>
    {
        private readonly IDyeingTBRChemicalRepository _dyeingTbrChemical;

        public UpdateDyeingTBRChemicalValueCommandValidator(IDyeingTBRChemicalRepository dyeingTbrChemical)
        {
            _dyeingTbrChemical = dyeingTbrChemical;

            RuleFor(p => p.DyeingTBRChemicalId)
                .MustAsync(IsExistDyeingTBRChemicalAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistDyeingTBRChemicalAsync(int dyeingTbrChemicalId, CancellationToken token)
        {
            return await _dyeingTbrChemical.IsExistAsync(dyeingTbrChemicalId);
        }
    }
}