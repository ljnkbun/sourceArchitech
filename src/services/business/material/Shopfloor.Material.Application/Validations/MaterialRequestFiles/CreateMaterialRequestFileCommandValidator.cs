using FluentValidation;
using Shopfloor.Material.Application.Command.MaterialRequestFiles;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Validations.MaterialRequestFiles
{
    public class CreateMaterialRequestFileCommandValidator : AbstractValidator<CreateMaterialRequestFileCommand>
    {
        private readonly IMaterialRequestRepository _materialRequest;

        public CreateMaterialRequestFileCommandValidator(IMaterialRequestRepository materialRequest)
        {
            _materialRequest = materialRequest;
            RuleFor(p => p.FileId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.FileName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.MaterialRequestId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int materialRequestId, CancellationToken token)
        {
            return await _materialRequest.IsExistAsync(materialRequestId);
        }
    }
}