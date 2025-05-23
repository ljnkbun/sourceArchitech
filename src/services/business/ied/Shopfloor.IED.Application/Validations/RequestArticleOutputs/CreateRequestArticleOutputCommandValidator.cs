﻿using FluentValidation;
using Shopfloor.IED.Application.Command.RequestArticleOutputs;

namespace Shopfloor.IED.Application.Validations.RequestArticleOutputs
{
    public class CreateRequestArticleOutputCommandValidator : AbstractValidator<CreateRequestArticleOutputCommand>
    {
        public CreateRequestArticleOutputCommandValidator()
        {
            RuleFor(p => p.ArticleCode)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Color)
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.BaseColorList)
                .MaximumLength(2000).WithMessage("{PropertyName} must not exceed 2000 characters.");
        }
    }
}
