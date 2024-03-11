using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionMesurements
{
    public class GetInspectionMesurementQuery : IRequest<Response<InspectionMesurement>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionMesurementQueryHandler : IRequestHandler<GetInspectionMesurementQuery, Response<InspectionMesurement>>
    {
        private readonly IInspectionMesurementRepository _repository;
        public GetInspectionMesurementQueryHandler(IInspectionMesurementRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<InspectionMesurement>> Handle(GetInspectionMesurementQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InspectionMesurements Not Found (Id:{query.Id}).");
            return new Response<InspectionMesurement>(entity);
        }
    }
}
