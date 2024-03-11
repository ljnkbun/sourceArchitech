using MediatR;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Query.OneHundredPointSystemDetails
{
    public class GetOneHundredPointSystemDetailQuery : IRequest<Response<OneHundredPointSystemDetail>>
    {
        public int Id { get; set; }
    }
    public class GetOneHundredPointSystemDetailQueryHandler : IRequestHandler<GetOneHundredPointSystemDetailQuery, Response<OneHundredPointSystemDetail>>
    {
        private readonly IOneHundredPointSystemDetailRepository _repository;
        public GetOneHundredPointSystemDetailQueryHandler(IOneHundredPointSystemDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<OneHundredPointSystemDetail>> Handle(GetOneHundredPointSystemDetailQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"OneHundredPointSystemDetails Not Found (Id:{query.Id}).");
            return new Response<OneHundredPointSystemDetail>(entity);
        }
    }
}
