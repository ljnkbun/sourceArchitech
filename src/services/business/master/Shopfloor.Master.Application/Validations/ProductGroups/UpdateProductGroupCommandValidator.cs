using FluentValidation;
using Shopfloor.Master.Application.Command.ProductGroups;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.ProductGroups
{
    public class UpdateProductGroupCommandValidator : AbstractValidator<UpdateProductGroupCommand>
    {
        private readonly IProductGroupRepository _repository;
        private readonly IMaterialTypeRepository _materialTypeRepository;
        public UpdateProductGroupCommandValidator(IProductGroupRepository repository, IMaterialTypeRepository materialTypeRepository)
        {
            _repository = repository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.CategoryId)
                .NotNull()
                .WithMessage("{PropertyName} must not Null.");

            RuleFor(p => p.MaterialTypeId)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
            .MustAsync(IsExistMaterialType).WithMessage("{PropertyName} not exists.");
            _materialTypeRepository = materialTypeRepository;

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsExistMaterialType(int id, CancellationToken cancellationToken)
        {
            return await _materialTypeRepository.GetByIdAsync(id) != null;
        }

        private async Task<bool> IsUniqueAsync(UpdateProductGroupCommand command, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
