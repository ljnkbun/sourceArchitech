using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectError4PointSyss
{
    public class GetInspectionDefectError4PointSysQuery : IRequest<Response<InspectionDefectError4PointSys>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionDefectError4PointSysQueryHandler : IRequestHandler<GetInspectionDefectError4PointSysQuery, Response<InspectionDefectError4PointSys>>
    {
        private readonly IInspectionDefectError4PointSysRepository _repository;
        public GetInspectionDefectError4PointSysQueryHandler(IInspectionDefectError4PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<InspectionDefectError4PointSys>> Handle(GetInspectionDefectError4PointSysQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InspectionDefectError4PointSyss Not Found (Id:{query.Id}).");
            return new Response<InspectionDefectError4PointSys>(entity);
        }
    }
}
