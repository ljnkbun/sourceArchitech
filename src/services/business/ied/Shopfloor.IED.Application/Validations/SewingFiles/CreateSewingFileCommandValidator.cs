﻿using FluentValidation;
using Shopfloor.IED.Application.Command.SewingFiles;

namespace Shopfloor.IED.Application.Validations.SewingFiles
{
    public class CreateSewingFileCommandValidator : AbstractValidator<CreateSewingFileCommand>
    {
        public CreateSewingFileCommandValidator()
        {
            RuleFor(p => p.SewingIEDId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.FileType).IsInEnum();

            RuleFor(p => p.FileName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.FileId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }
    }
}
