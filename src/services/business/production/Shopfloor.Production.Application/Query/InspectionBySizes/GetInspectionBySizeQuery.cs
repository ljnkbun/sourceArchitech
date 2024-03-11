using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Query.InspectionBySizes
{
    public class GetInspectionBySizeQuery : IRequest<Response<InspectionBySize>>
    {
        public int Id { get; set; }
    }
    public class GetInspectionBySizeQueryHandler : IRequestHandler<GetInspectionBySizeQuery, Response<InspectionBySize>>
    {
        private readonly IInspectionBySizeRepository _repository;
        public GetInspectionBySizeQueryHandler(IInspectionBySizeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<InspectionBySize>> Handle(GetInspectionBySizeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"InspectionBySize Not Found (Id:{query.Id}).");
            return new Response<InspectionBySize>(entity);
        }
    }
}
