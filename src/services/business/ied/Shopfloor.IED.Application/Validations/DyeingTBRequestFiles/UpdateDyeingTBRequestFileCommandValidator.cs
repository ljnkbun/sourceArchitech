using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRequestFiles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBRequestFiles
{
    public class UpdateDyeingTBRequestFileCommandValidator : AbstractValidator<UpdateDyeingTBRequestFileCommand>
    {
        private readonly IDyeingTBRequestRepository _dyeingTbRequestRepository;

        public UpdateDyeingTBRequestFileCommandValidator(IDyeingTBRequestRepository dyeingTbRequestRepository)
        {
            _dyeingTbRequestRepository = dyeingTbRequestRepository;
            RuleFor(p => p.FileId)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.FileName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DyeingTBRequestId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dyeingTbRequestId, CancellationToken token)
        {
            return await _dyeingTbRequestRepository.IsExistAsync(dyeingTbRequestId);
        }
    }
}