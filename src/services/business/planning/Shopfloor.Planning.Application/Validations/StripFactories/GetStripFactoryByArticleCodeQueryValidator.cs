using FluentValidation;
using Shopfloor.Planning.Application.Query.StripFactories;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Validations.StripFactories
{
    public class GetStripFactoryByArticleCodeQueryValidator : AbstractValidator<GetStripFactoryByArticleCodeQuery>
    {
        private readonly IPORRepository _repository;
        public GetStripFactoryByArticleCodeQueryValidator(IPORRepository repository)
        {
            _repository = repository;

            RuleFor(p => p)
                .MustAsync(ValidatorArticleCodePor)
                .WithMessage("{PropertyName} Not Found in POR.");
        }

        private async Task<bool> ValidatorArticleCodePor(GetStripFactoryByArticleCodeQuery command, CancellationToken cancellationToken)
        {
            return await _repository.CheckAnyArticleCodeInPor(command.ArticleCode);
        }
    }
}
