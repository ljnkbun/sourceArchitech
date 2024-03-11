using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingOperations;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingOperations
{
    public class CreateWeavingOperationCommandValidator : AbstractValidator<CreateWeavingOperationCommand>
    {
        private readonly IWeavingRoutingRepository _weavingRouting;

        public CreateWeavingOperationCommandValidator(IWeavingRoutingRepository weavingRouting)
        {
            _weavingRouting = weavingRouting;
            RuleFor(p => p.ArticleCode)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.ArticleName)
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.LineNumber)
                .GreaterThan(0).WithMessage("{PropertyName} is required.");
            RuleFor(p => p.Operation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.MachineType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
            RuleFor(p => p.WeavingRoutingId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");

            RuleForEach(p => p.WeavingOperationInputArticles).ChildRules(childWeavingOperationInputArticles =>
            {
                childWeavingOperationInputArticles.RuleFor(p => p.ArticleCode)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
                childWeavingOperationInputArticles.RuleFor(p => p.ArticleName)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
                childWeavingOperationInputArticles.RuleFor(p => p.WFXArticleId)
                    .GreaterThan(0).WithMessage("{PropertyName} is required.");
            });
        }

        private async Task<bool> IsExistAsync(int weavingRoutingId, CancellationToken token)
        {
            return await _weavingRouting.IsExistAsync(weavingRoutingId);
        }
    }
}