using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturing100Pointss
{
    public class GetDefectCapturing100PointsQuery : IRequest<Response<DefectCapturing100Points>>
    {
        public int Id { get; set; }
    }
    public class GetDefectCapturing100PointsQueryHandler : IRequestHandler<GetDefectCapturing100PointsQuery, Response<DefectCapturing100Points>>
    {
        private readonly IDefectCapturing100PointsRepository _repository;
        public GetDefectCapturing100PointsQueryHandler(IDefectCapturing100PointsRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<DefectCapturing100Points>> Handle(GetDefectCapturing100PointsQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DefectCapturing100Points Not Found (Id:{query.Id}).");
            return new Response<DefectCapturing100Points>(entity);
        }
    }
}
