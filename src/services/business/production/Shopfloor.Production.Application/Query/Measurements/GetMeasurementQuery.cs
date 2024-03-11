using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.Measurements
{
    public class GetMeasurementQuery : IRequest<Response<Measurement>>
    {
        public int Id { get; set; }
    }
    public class GetMeasurementQueryHandler : IRequestHandler<GetMeasurementQuery, Response<Measurement>>
    {
        private readonly IMeasurementRepository _repository;
        public GetMeasurementQueryHandler(IMeasurementRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Measurement>> Handle(GetMeasurementQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Measurement Not Found (Id:{query.Id}).");
            return new Response<Measurement>(entity);
        }
    }
}
