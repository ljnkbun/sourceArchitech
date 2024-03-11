using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.DefectCapturings
{
    public class GetDefectCapturingQuery : IRequest<Response<DefectCapturing>>
    {
        public int Id { get; set; }
    }
    public class GetDefectCapturingQueryHandler : IRequestHandler<GetDefectCapturingQuery, Response<DefectCapturing>>
    {
        private readonly IDefectCapturingRepository _repository;
        public GetDefectCapturingQueryHandler(IDefectCapturingRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<DefectCapturing>> Handle(GetDefectCapturingQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DefectCapturing Not Found (Id:{query.Id}).");
            return new Response<DefectCapturing>(entity);
        }
    }
}
