﻿using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBMaterials;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.DyeingTBMaterials
{
    public class CreateDyeingTBMaterialCommandValidator : AbstractValidator<CreateDyeingTBMaterialCommand>
    {
        private readonly IDyeingTBRequestRepository _dyeingTbRequestRepository;

        public CreateDyeingTBMaterialCommandValidator(IDyeingTBRequestRepository dyeingTbRequestRepository)
        {
            _dyeingTbRequestRepository = dyeingTbRequestRepository;

            RuleFor(p => p.WFXArticleId)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ArticleCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ArticleName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.MaterialType)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.FabricContent)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.FabricStyleRef)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.Lights)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.DyeingTBRequestId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");

            RuleForEach(p => p.DyeingTBMaterialColors).ChildRules(childDyeingTBMaterialColor =>
            {
                childDyeingTBMaterialColor.RuleFor(p => p.Color)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                childDyeingTBMaterialColor.RuleFor(p => p.Pantone)
                    .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                childDyeingTBMaterialColor.RuleFor(p => p.Status)
                    .IsInEnum().WithMessage("Value is not part of the enum.");
            });
        }

        private async Task<bool> IsExistAsync(int dyeingTbRequestId, CancellationToken token)
        {
            return await _dyeingTbRequestRepository.IsExistAsync(dyeingTbRequestId);
        }
    }
}