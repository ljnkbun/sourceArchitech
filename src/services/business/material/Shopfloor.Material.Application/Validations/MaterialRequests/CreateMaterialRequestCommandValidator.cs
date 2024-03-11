using FluentValidation;
using Shopfloor.Material.Application.Command.MaterialRequests;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Validations.MaterialRequests
{
    public class CreateMaterialRequestCommandValidator : AbstractValidator<CreateMaterialRequestCommand>
    {
        public readonly IMaterialRequestDynamicColumnRepository _repositoryMaterialRequestDynamicColumn;

        public CreateMaterialRequestCommandValidator(IMaterialRequestDynamicColumnRepository repositoryMaterialRequestDynamicColumn)
        {
            _repositoryMaterialRequestDynamicColumn = repositoryMaterialRequestDynamicColumn;

            #region Global
            RuleFor(p => p.HSCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleForEach(item => item.DynamicColumns).ChildRules(p =>
            {
                p.RuleFor(x => x.DynamicColumnId)
                    .GreaterThan(0)
                    .WithMessage("{PropertyName} must greater than 0.")
                    .MustAsync(IsExistAsync)
                    .WithMessage("{PropertyName} not found.");
            });

            #endregion Global
        }

        private async Task<bool> IsExistAsync(int dynamicColumnId, CancellationToken cancellationToken)
        {
            return await _repositoryMaterialRequestDynamicColumn.IsExistAsync(dynamicColumnId);
        }
    }
}