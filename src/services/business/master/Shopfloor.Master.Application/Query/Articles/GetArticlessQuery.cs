using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Articles
{
    public class GetArticlessQuery : IRequest<Response<List<Article>>>
    {
        public List<string> ArticleCode { get; set; }
    }

    public class GetArticlessQueryHandler : IRequestHandler<GetArticlessQuery, Response<List<Article>>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _repository;
        public GetArticlessQueryHandler(IMapper mapper,
            IArticleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<List<Article>>> Handle(GetArticlessQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetByArticleCodeAsync(request.ArticleCode);
            if (entities == null) return new($"Article Not Found.");
            return new Response<List<Article>>(entities.ToList());
        }
    }
}
