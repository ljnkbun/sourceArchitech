﻿using FluentValidation;
using Shopfloor.Master.Application.Parameters.FabricWidths;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.FabricWidths
{
    public class CreateFabricWidthCommandValidator : AbstractValidator<FabricWidthParameter>
    {
        private readonly IFabricWidthRepository _fabricWidthRepository;
        public CreateFabricWidthCommandValidator(IFabricWidthRepository fabricWidthRepository)
        {
            _fabricWidthRepository = fabricWidthRepository; 
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.")
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        }
        private async Task<bool> IsUniqueAsync(string code, CancellationToken cancellationToken)
        {
            return await _fabricWidthRepository.IsUniqueAsync(code);
        }
    }
}
