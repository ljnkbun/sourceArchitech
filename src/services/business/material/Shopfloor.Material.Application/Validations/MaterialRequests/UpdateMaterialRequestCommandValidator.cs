using FluentValidation;
using Shopfloor.Material.Application.Command.MaterialRequests;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Validations.MaterialRequests
{
    public class UpdateMaterialRequestCommandValidator : AbstractValidator<UpdateMaterialRequestCommand>
    {
        public readonly IMaterialRequestDynamicColumnRepository _repositoryMaterialRequestDynamicColumn;

        public UpdateMaterialRequestCommandValidator(IMaterialRequestDynamicColumnRepository repositoryMaterialRequestDynamicColumn)
        {
            _repositoryMaterialRequestDynamicColumn = repositoryMaterialRequestDynamicColumn;

            RuleFor(p => p.HSCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleForEach(item => item.DynamicColumns).ChildRules(p =>
            {
                p.RuleFor(x => x.DynamicColumnId)
                    .GreaterThan(0)
                    .WithMessage("{PropertyName} must greater than 0.");

                p.RuleFor(x => x)
                    .MustAsync((z, cancellation) => IsUniqueAsync(z.DynamicColumnId, z.Id, cancellation))
                    .WithMessage("{PropertyName} must unique.");
            });
        }

        private async Task<bool> IsUniqueAsync(int dynamicColumnId, int id, CancellationToken cancellationToken)
        {
            return await _repositoryMaterialRequestDynamicColumn.IsUniqueAsync(dynamicColumnId, id);
        }
    }
}