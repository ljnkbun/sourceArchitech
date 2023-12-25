﻿using FluentValidation;
using Shopfloor.Master.Application.Command.Genders;
using Shopfloor.Master.Application.Command.MaterialTypes;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.MaterialTypes
{
    public class UpdateMaterialTypeCommandValidator : AbstractValidator<UpdateMaterialTypeCommand>
    {
        private readonly IMaterialTypeRepository _materialTypeRepository;
        public UpdateMaterialTypeCommandValidator(IMaterialTypeRepository materialTypeRepository)
        {
            _materialTypeRepository = materialTypeRepository;
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateMaterialTypeCommand command, CancellationToken cancellationToken)
        {
            return await _materialTypeRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
