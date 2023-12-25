using FluentValidation;

using Shopfloor.Material.Application.Command.DynamicColumns;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Validations.DynamicColumns
{
    public class UpdateDynamicColumnCommandValidator : AbstractValidator<UpdateDynamicColumnCommand>
    {
        private readonly IDynamicColumnRepository _dynamicColumnRepository;

        public UpdateDynamicColumnCommandValidator(IDynamicColumnRepository dynamicColumnRepository)
        {
            _dynamicColumnRepository = dynamicColumnRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p)
                .MustAsync(IsUniqueAsync)
                .WithMessage("Code must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CategoryCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.FieldType)
                .IsInEnum().WithMessage("{PropertyName} is not part of the enum.");

            RuleFor(p => p.DisplayIndex)
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must greater than or equal to 0.");
        }

        private async Task<bool> IsUniqueAsync(UpdateDynamicColumnCommand command, CancellationToken cancellationToken)
        {
            return await _dynamicColumnRepository.IsUniqueAsync(command.Code, command.CategoryCode, command.Id);
        }
    }
}