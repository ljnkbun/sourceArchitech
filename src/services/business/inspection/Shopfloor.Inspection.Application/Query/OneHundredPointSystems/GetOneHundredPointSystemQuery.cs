using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.OneHundredPointSystems
{
    public class GetOneHundredPointSystemQuery : IRequest<Response<OneHundredPointSystem>>
    {
        public int Id { get; set; }
    }
    public class GetOneHundredPointSystemQueryHandler : IRequestHandler<GetOneHundredPointSystemQuery, Response<OneHundredPointSystem>>
    {
        private readonly IOneHundredPointSystemRepository _repository;
        public GetOneHundredPointSystemQueryHandler(IOneHundredPointSystemRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<OneHundredPointSystem>> Handle(GetOneHundredPointSystemQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"OneHundredPointSystems Not Found (Id:{query.Id}).");
            return new Response<OneHundredPointSystem>(entity);
        }
    }
}
