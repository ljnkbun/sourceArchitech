using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturing4Pointss
{
    public class GetDefectCapturing4PointsQuery : IRequest<Response<DefectCapturing4Points>>
    {
        public int Id { get; set; }
    }
    public class GetDefectCapturing4PointsQueryHandler : IRequestHandler<GetDefectCapturing4PointsQuery, Response<DefectCapturing4Points>>
    {
        private readonly IDefectCapturing4PointsRepository _repository;
        public GetDefectCapturing4PointsQueryHandler(IDefectCapturing4PointsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<DefectCapturing4Points>> Handle(GetDefectCapturing4PointsQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DefectCapturing4Points Not Found (Id:{query.Id}).");
            return new Response<DefectCapturing4Points>(entity);
        }
    }
}
