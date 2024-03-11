using MediatR;
using Shopfloor.Planning.Application.Models.StripFactories;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.StripFactories
{
    public class GetStripFactoryByArticleCodeQuery : IRequest<IReadOnlyList<StripFactoryModel>>
    {
        public string ArticleCode { get; set; }
    }

    public class GetStripFactoryByArticleCodeQueryHandler : IRequestHandler<GetStripFactoryByArticleCodeQuery, IReadOnlyList<StripFactoryModel>>
    {
        private readonly IStripFactoryRepository _stripFactoryRepository;

        public GetStripFactoryByArticleCodeQueryHandler(IStripFactoryRepository stripFactoryRepository)
        {
            _stripFactoryRepository = stripFactoryRepository;
        }

        public async Task<IReadOnlyList<StripFactoryModel>> Handle(GetStripFactoryByArticleCodeQuery request, CancellationToken cancellationToken)
        {
            return await _stripFactoryRepository.GetModelByArticleCodeAsync<StripFactoryModel>(request.ArticleCode);
        }
    }
}
