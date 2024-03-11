using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Ports
{
    public class GetPortQuery : IRequest<Response<Port>>
    {
        public int Id { get; set; }
    }
    public class GetPortQueryHandler : IRequestHandler<GetPortQuery, Response<Port>>
    {
        private readonly IPortRepository _repository;
        public GetPortQueryHandler(IPortRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Port>> Handle(GetPortQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Port Not Found (Id:{query.Id}).");
            return new Response<Port>(entity);
        }
    }
}
