﻿using FluentValidation;
using Shopfloor.Master.Application.Command.CompanyCurrencies;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Validations.CompanyCurrencies
{
    public class UpdateCompanyCurrencyCommandValidator : AbstractValidator<UpdateCompanyCurrencyCommand>
    {
        private readonly ICompanyCurrencyRepository _companyCurrencyRepository;
        public UpdateCompanyCurrencyCommandValidator(ICompanyCurrencyRepository companyCurrencyRepository)
        {
            _companyCurrencyRepository = companyCurrencyRepository;

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            #region Check existed code
            RuleFor(p => p)
                .MustAsync(IsUniqueAsync).WithMessage("{PropertyName} must unique.");
            #endregion
        }

        private async Task<bool> IsUniqueAsync(UpdateCompanyCurrencyCommand command, CancellationToken cancellationToken)
        {
            return await _companyCurrencyRepository.IsUniqueAsync(command.Code, command.Id);
        }
    }
}
