using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Patterns
{
    public class GetPatternQuery : IRequest<Response<Pattern>>
    {
        public int Id { get; set; }
    }
    public class GetPatternQueryHandler : IRequestHandler<GetPatternQuery, Response<Pattern>>
    {
        private readonly IPatternRepository _repository;
        public GetPatternQueryHandler(IPatternRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Pattern>> Handle(GetPatternQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Pattern Not Found (Id:{query.Id}).");
            return new Response<Pattern>(entity);
        }
    }
}
