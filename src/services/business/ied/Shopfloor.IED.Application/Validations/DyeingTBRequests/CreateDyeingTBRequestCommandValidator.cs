using FluentValidation;
using Shopfloor.IED.Application.Command.DyeingTBRequests;

namespace Shopfloor.IED.Application.Validations.DyeingTBRequests
{
    public class CreateDyeingTBRequestCommandValidator : AbstractValidator<CreateDyeingTBRequestCommand>
    {
        public CreateDyeingTBRequestCommandValidator()
        {
            RuleFor(p => p.Remark)
                .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.StyleRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Buyer)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.BuyerRef)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.RequestDate)
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.ExpiredDate)
                .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleForEach(p => p.DyeingTBRequestFiles).ChildRules(childDyeingTBRequestFile =>
             {
                 childDyeingTBRequestFile.RuleFor(p => p.FileId)
                     .NotEmpty().WithMessage("{PropertyName} is required.")
                     .NotNull()
                     .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                 childDyeingTBRequestFile.RuleFor(p => p.FileName)
                     .NotEmpty().WithMessage("{PropertyName} is required.")
                     .NotNull()
                     .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                 childDyeingTBRequestFile.RuleFor(p => p.Description)
                     .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

             });

            RuleForEach(p => p.DyeingTBMaterials).ChildRules(childDyeingTBMaterial =>
             {
                 childDyeingTBMaterial.RuleFor(p => p.WFXArticleId)
                     .NotEmpty().WithMessage("{PropertyName} is required.");

                 childDyeingTBMaterial.RuleFor(p => p.ArticleCode)
                     .NotEmpty().WithMessage("{PropertyName} is required.")
                     .NotNull()
                     .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                 childDyeingTBMaterial.RuleFor(p => p.FabricStyleRef)
                     .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                 childDyeingTBMaterial.RuleFor(p => p.ArticleName)
                     .NotEmpty().WithMessage("{PropertyName} is required.")
                     .NotNull()
                     .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                 childDyeingTBMaterial.RuleFor(p => p.MaterialType)
                     .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                 childDyeingTBMaterial.RuleFor(p => p.FabricContent)
                     .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                 childDyeingTBMaterial.RuleFor(p => p.Lights)
                     .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                 childDyeingTBMaterial.RuleForEach(p => p.DyeingTBMaterialColors).ChildRules(childDyeingTBMaterialColor =>
                 {
                     childDyeingTBMaterialColor.RuleFor(p => p.Color)
                         .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");

                     childDyeingTBMaterialColor.RuleFor(p => p.Pantone)
                         .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");

                     childDyeingTBMaterialColor.RuleFor(p => p.Status)
                         .IsInEnum().WithMessage("Value is not part of the enum.");
                 });
             });
        }
    }
}