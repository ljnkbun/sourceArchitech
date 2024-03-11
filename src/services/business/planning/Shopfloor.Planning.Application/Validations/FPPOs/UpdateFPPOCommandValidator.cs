using FluentValidation;
using Shopfloor.Planning.Application.Command.FPPOs;

namespace Shopfloor.Planning.Application.Validations.FPPOs
{   
    public class UpdateFPPOCommandValidator : AbstractValidator<UpdateFPPOCommand>
    {
        public UpdateFPPOCommandValidator()
        {
            RuleFor(p => p.FPPONo)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.OCNo)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.WFXDeliveryOrderCode)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Supplier)
                .MaximumLength(500)
                .WithMessage("{PropertyName} must not exceed 500 characters.");

            RuleFor(p => p.WipDispatchSite)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.WipReceivingSite)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.PORNo)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.BatchNo)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.JobOrderNo)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ProcessCode)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ProcessName)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleCode)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.ArticleName)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");

            RuleFor(p => p.Start)
               .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.End)
               .GreaterThan(new DateTime(1970, 1, 1, 12, 0, 0, DateTimeKind.Local));

            RuleFor(p => p.UOM)
                .MaximumLength(250)
                .WithMessage("{PropertyName} must not exceed 250 characters.");
        }
    }
}
