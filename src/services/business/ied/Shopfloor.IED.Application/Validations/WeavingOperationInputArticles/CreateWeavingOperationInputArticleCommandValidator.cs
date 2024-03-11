using FluentValidation;
using Shopfloor.IED.Application.Command.WeavingOperationInputArticles;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Validations.WeavingOperationInputArticles
{
    public class CreateWeavingOperationInputArticleCommandValidator : AbstractValidator<CreateWeavingOperationInputArticleCommand>
    {
        private readonly IWeavingOperationRepository _weavingOperation;

        public CreateWeavingOperationInputArticleCommandValidator(IWeavingOperationRepository weavingOperation)
        {
            _weavingOperation = weavingOperation;

            RuleFor(p => p.ArticleCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.ArticleName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters.");
            RuleFor(p => p.WFXArticleId)
                .GreaterThan(0).WithMessage("{PropertyName} is required.");

            RuleFor(p => p.WeavingOperationId)
                .MustAsync(IsExistAsync)
                .WithMessage("{PropertyName} not found.");
        }

        private async Task<bool> IsExistAsync(int weavingOperationId, CancellationToken token)
        {
            return await _weavingOperation.IsExistAsync(weavingOperationId);
        }
    }
}