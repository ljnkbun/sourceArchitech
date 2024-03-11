using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingRoutings;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingRoutings
{
    public class CreateDyeingRoutingsCommandValidator : AbstractValidator<CreateDyeingRoutingsCommand>
    {
        private readonly IDyeingIEDRepository _dyeingIed;

        public CreateDyeingRoutingsCommandValidator(IDyeingIEDRepository dyeingIed)
        {
            _dyeingIed = dyeingIed;
            RuleForEach(x => x.DyeingRoutings).ChildRules(child =>
            {
                child.RuleFor(p => p.DyeingProcess)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.DyeingOperation)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.MachineCode)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.MachineName)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                child.RuleFor(p => p.DyeingProcessCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.DyeingOperationCode)
                    .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                child.RuleFor(p => p.DyeingIEDId)
                    .MustAsync(IsExistAsync)
                    .WithMessage("{PropertyName} not found.");
            });
        }

        private async Task<bool> IsExistAsync(int dyeingIEDId, CancellationToken token)
        {
            return await _dyeingIed.IsExistAsync(dyeingIEDId);
        }
    }
}