using FluentValidation;
using NPOI.POIFS.Properties;
using Shopfloor.IED.Application.Command.DyeingRoutings;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingRoutings
{
    public class UpdateDyeingRoutingCommandValidator : AbstractValidator<UpdateDyeingRoutingCommand>
    {
          private readonly IDyeingIEDRepository _dyeingIed;

        public UpdateDyeingRoutingCommandValidator(IDyeingIEDRepository dyeingIed)
        {
            _dyeingIed = dyeingIed;

            RuleFor(p => p.DyeingProcess)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingOperation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingProcessCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.DyeingOperationCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.MachineCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.MachineName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.DyeingIEDId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingIEDId, CancellationToken token)
        {
            return await _dyeingIed.IsExistAsync(dyeingIEDId);
        }
    }
}