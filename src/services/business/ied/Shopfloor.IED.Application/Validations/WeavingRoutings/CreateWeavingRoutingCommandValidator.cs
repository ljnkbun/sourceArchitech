using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingRoutings
{
    public class CreateWeavingRoutingCommandValidator : AbstractValidator<CreateWeavingRoutingCommand>
    {
        private readonly IWeavingOperationRepository _weavingOperation;

        public CreateWeavingRoutingCommandValidator(IWeavingOperationRepository weavingOperation)
        {
            _weavingOperation = weavingOperation;
         
            RuleFor(p => p.WeavingProcess)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.WeavingProcessCode)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleForEach(p => p.WeavingOperations).ChildRules(childWeavingOperations =>
            {
                childWeavingOperations.RuleFor(p => p.ArticleCode)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
                childWeavingOperations.RuleFor(p => p.ArticleName)
                    .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
                childWeavingOperations.RuleFor(p => p.LineNumber)
                    .GreaterThan(0).WithMessage("{PropertyName} is required.");
                childWeavingOperations.RuleFor(p => p.Operation)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
                childWeavingOperations.RuleFor(p => p.MachineType)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

                childWeavingOperations.RuleForEach(p => p.WeavingOperationInputArticles).ChildRules(childWeavingOperationInputArticles =>
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
                    childWeavingOperationInputArticles.RuleFor(p => p.WeavingOperationId)
                        .MustAsync(IsExistWeavingOperationAsync)
                        .WithMessage("{PropertyName} not found.");
                });
            });
        }

        private async Task<bool> IsExistWeavingOperationAsync(int weavingOperationId, CancellationToken token)
        {
            return await _weavingOperation.IsExistAsync(weavingOperationId);
        }
    }
}