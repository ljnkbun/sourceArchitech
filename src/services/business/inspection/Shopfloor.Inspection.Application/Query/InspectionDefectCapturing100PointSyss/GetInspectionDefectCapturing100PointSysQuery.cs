using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectCapturing100PointSyss
{
    public class GetInspectionDefectCapturing100PointSysQuery : IRequest<Response<InspectionDefectCapturing100PointSys>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionDefectCapturing100PointSysQueryHandler : IRequestHandler<GetInspectionDefectCapturing100PointSysQuery, Response<InspectionDefectCapturing100PointSys>>
    {
        private readonly IInspectionDefectCapturing100PointSysRepository _repository;
        public GetInspectionDefectCapturing100PointSysQueryHandler(IInspectionDefectCapturing100PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<InspectionDefectCapturing100PointSys>> Handle(GetInspectionDefectCapturing100PointSysQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InspectionDefectCapturing100PointSyss Not Found (Id:{query.Id}).");
            return new Response<InspectionDefectCapturing100PointSys>(entity);
        }
    }
}
