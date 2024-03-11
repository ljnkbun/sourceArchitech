using FluentValidation;
using Shopfloor.Master.Application.Command.ProductGroupUOMs;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.CategoryMapMaterialTypes
{
    public class UpdateProductGroupUOMCommandValidator : AbstractValidator<UpdateProductGroupUOMCommand>
    {
        private readonly IProductGroupUOMRepository _productGroupUomRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IUOMRepository _uomRepository;

        public UpdateProductGroupUOMCommandValidator(IProductGroupUOMRepository productGroupUomRepository, IProductGroupRepository productGroupRepository, IUOMRepository uomRepository)
        {
            _productGroupUomRepository = productGroupUomRepository;
            _productGroupRepository = productGroupRepository;
            _uomRepository = uomRepository;

            RuleFor(p => p.ProductGroupId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistProductGroup);

            RuleFor(p => p.UOMId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(IsExistUOM);

            RuleFor(p => p)
                .MustAsync(IsDuplicateAsync).WithMessage("Data exists");
        }

        private async Task<bool> IsDuplicateAsync(UpdateProductGroupUOMCommand command, CancellationToken cancellationToken)
        {
            return await _productGroupUomRepository.IsDuplicateAsync(command.ProductGroupId, command.UOMId);
        }

        private async Task<bool> IsExistProductGroup(int id, CancellationToken cancellationToken)
        {
            return await _productGroupRepository.IsExistAsync(id);
        }

        private async Task<bool> IsExistUOM(int id, CancellationToken cancellationToken)
        {
            return await _uomRepository.IsExistAsync(id);
        }
    }
}