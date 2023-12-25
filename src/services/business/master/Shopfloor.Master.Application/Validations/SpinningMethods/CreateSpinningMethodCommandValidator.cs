﻿using FluentValidation;
using Shopfloor.Master.Application.Command.SpinningMethods;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.SpinningMethods
{
    public class CreateSpinningMethodCommandValidator : AbstractValidator<CreateSpinningMethodCommand>
    {
        private readonly ISpinningMethodRepository _spinningMethodRepository;
        public CreateSpinningMethodCommandValidator(ISpinningMethodRepository spinningMethodRepository)
        {
            _spinningMethodRepository = spinningMethodRepository;
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
            return await _spinningMethodRepository.IsUniqueAsync(code);
        }
    }
}
