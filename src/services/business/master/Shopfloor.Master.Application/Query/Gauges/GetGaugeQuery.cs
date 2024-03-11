using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Gauges
{
    public class GetGaugeQuery : IRequest<Response<Gauge>>
    {
        public int Id { get; set; }
    }
    public class GetGaugeQueryHandler : IRequestHandler<GetGaugeQuery, Response<Gauge>>
    {
        private readonly IGaugeRepository _repository;
        public GetGaugeQueryHandler(IGaugeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Gauge>> Handle(GetGaugeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Gauge Not Found (Id:{query.Id}).");
            return new Response<Gauge>(entity);
        }
    }
}
