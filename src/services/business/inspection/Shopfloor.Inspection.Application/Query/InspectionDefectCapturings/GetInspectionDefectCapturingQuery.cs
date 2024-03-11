using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.InspectionDefectCapturings
{
    public class GetInspectionDefectCapturingQuery : IRequest<Response<InspectionDefectCapturing>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionDefectCapturingQueryHandler : IRequestHandler<GetInspectionDefectCapturingQuery, Response<InspectionDefectCapturing>>
    {
        private readonly IInspectionDefectCapturingRepository _repository;
        public GetInspectionDefectCapturingQueryHandler(IInspectionDefectCapturingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<InspectionDefectCapturing>> Handle(GetInspectionDefectCapturingQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InspectionDefectCapturings Not Found (Id:{query.Id}).");
            return new Response<InspectionDefectCapturing>(entity);
        }
    }
}
