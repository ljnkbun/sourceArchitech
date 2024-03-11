using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectCapturing4PointSyss
{
    public class GetInspectionDefectCapturing4PointSysQuery : IRequest<Response<InspectionDefectCapturing4PointSys>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionDefectCapturing4PointSysQueryHandler : IRequestHandler<GetInspectionDefectCapturing4PointSysQuery, Response<InspectionDefectCapturing4PointSys>>
    {
        private readonly IInspectionDefectCapturing4PointSysRepository _repository;
        public GetInspectionDefectCapturing4PointSysQueryHandler(IInspectionDefectCapturing4PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<InspectionDefectCapturing4PointSys>> Handle(GetInspectionDefectCapturing4PointSysQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InspectionDefectCapturing4PointSyss Not Found (Id:{query.Id}).");
            return new Response<InspectionDefectCapturing4PointSys>(entity);
        }
    }
}
