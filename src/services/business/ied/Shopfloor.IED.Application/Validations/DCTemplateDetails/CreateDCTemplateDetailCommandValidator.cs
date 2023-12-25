﻿using FluentValidation;
using Shopfloor.IED.Application.Command.DCTemplateDetails;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DCTemplateDetails
{
    public class CreateDCTemplateDetailCommandValidator : AbstractValidator<CreateDCTemplateDetailCommand>
    {
        private readonly IDCTemplateTaskRepository _dcTemplateTask;

        public CreateDCTemplateDetailCommandValidator(IDCTemplateTaskRepository dcTemplateTask)
        {
            _dcTemplateTask = dcTemplateTask;

            RuleFor(p => p.ChemicalCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ChemicalName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Unit)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DCTemplateTaskId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int dcTemplateTaskId, CancellationToken token)
        {
            return await _dcTemplateTask.IsExistAsync(dcTemplateTaskId);
        }
    }
}