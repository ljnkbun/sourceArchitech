using FluentValidation;
using Shopfloor.Master.Application.Command.MaterialTypeMapProductGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.MaterialTypeMapProductGroups
{
    public class CreateMaterialTypeMapProductGroupCommandValidator : AbstractValidator<CreateMaterialTypeMapProductGroupCommand>
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        private readonly IMaterialTypeMapProductGroupRepository _materialTypeMapProductGroupRepository;
        public CreateMaterialTypeMapProductGroupCommandValidator(IProductGroupRepository productGroupRepository, IMaterialTypeRepository materialTypeRepository, IMaterialTypeMapProductGroupRepository materialTypeMapProductGroupRepository)
        {
            _productGroupRepository = productGroupRepository;
            _materialTypeRepository = materialTypeRepository;
            _materialTypeMapProductGroupRepository = materialTypeMapProductGroupRepository;

            RuleFor(p => p.ProductGroupId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistProductGroup);

            RuleFor(p => p.MaterialTypeId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistMaterialType);

            RuleFor(p => p)
            .MustAsync(IsDuplicateAsync).WithMessage("Data exists");
        }
        private async Task<bool> IsDuplicateAsync(CreateMaterialTypeMapProductGroupCommand command, CancellationToken cancellationToken)
        {
            return await _materialTypeMapProductGroupRepository.IsDuplicateAsync(command.MaterialTypeId, command.ProductGroupId);
        }
        private async Task<bool> IsExistProductGroup(int id, CancellationToken cancellationToken)
        {
            return await _productGroupRepository.GetByIdAsync(id) != null;
        }
        private async Task<bool> IsExistMaterialType(int id, CancellationToken cancellationToken)
        {
            return await _materialTypeRepository.GetByIdAsync(id) != null;
        }
    }
}
