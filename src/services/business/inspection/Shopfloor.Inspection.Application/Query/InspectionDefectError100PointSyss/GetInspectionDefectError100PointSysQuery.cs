using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectError100PointSyss
{
    public class GetInspectionDefectError100PointSysQuery : IRequest<Response<InspectionDefectError100PointSys>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionDefectError100PointSysQueryHandler : IRequestHandler<GetInspectionDefectError100PointSysQuery, Response<InspectionDefectError100PointSys>>
    {
        private readonly IInspectionDefectError100PointSysRepository _repository;
        public GetInspectionDefectError100PointSysQueryHandler(IInspectionDefectError100PointSysRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<InspectionDefectError100PointSys>> Handle(GetInspectionDefectError100PointSysQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InspectionDefectError100PointSyss Not Found (Id:{query.Id}).");
            return new Response<InspectionDefectError100PointSys>(entity);
        }
    }
}
