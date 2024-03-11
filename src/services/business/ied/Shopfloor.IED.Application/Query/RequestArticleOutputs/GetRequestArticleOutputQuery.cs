using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestArticleOutputs
{
    public class GetRequestArticleOutputQuery : IRequest<Response<RequestArticleOutput>>
    {
        public int Id { get; set; }
    }
    public class GetRequestArticleOutputQueryHandler : IRequestHandler<GetRequestArticleOutputQuery, Response<RequestArticleOutput>>
    {
        private readonly IRequestArticleOutputRepository _repository;
        public GetRequestArticleOutputQueryHandler(IRequestArticleOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<RequestArticleOutput>> Handle(GetRequestArticleOutputQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetRequestArticleOutputByIdAsync(query.Id);
            if (entity == null) return new($"RequestArticleOutput Not Found (Id:{query.Id}).");
            return new Response<RequestArticleOutput>(entity);
        }
    }
}
