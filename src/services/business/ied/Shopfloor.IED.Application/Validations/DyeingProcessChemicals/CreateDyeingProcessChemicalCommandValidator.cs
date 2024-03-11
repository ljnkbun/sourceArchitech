using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingProcessChemicals;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingProcessChemicals
{
    public class CreateDyeingProcessChemicalCommandValidator : AbstractValidator<CreateDyeingProcessChemicalCommand>
    {
        private readonly IDyeingRoutingRepository _dyeingRouting;

        public CreateDyeingProcessChemicalCommandValidator(IDyeingRoutingRepository dyeingRouting)
        {
            _dyeingRouting = dyeingRouting;

            RuleFor(p => p.ChemicalCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.ChemicalName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.SubCategoryCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.SubCategoryName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Unit)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingRoutingId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingRoutingId, CancellationToken token)
        {
            return await _dyeingRouting.IsExistAsync(dyeingRoutingId);
        }
    }
}