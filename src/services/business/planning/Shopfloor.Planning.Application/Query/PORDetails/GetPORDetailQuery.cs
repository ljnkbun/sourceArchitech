using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Query.PORDetails
{
    public class GetPORDetailQuery : IRequest<Response<PORDetail>>
    {
        public int Id { get; set; }
    }
    public class GetPORDetailQueryQueryHandler : IRequestHandler<GetPORDetailQuery, Response<PORDetail>>
    {
        private readonly IPORDetailRepository _repository;
        public GetPORDetailQueryQueryHandler(IPORDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<PORDetail>> Handle(GetPORDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"PORDetail Not Found (Id:{query.Id}).");
            return new Response<PORDetail>(entity);
        }
    }
}
