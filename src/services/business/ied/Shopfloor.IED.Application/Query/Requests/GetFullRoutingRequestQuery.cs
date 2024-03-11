using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Requests
{
    public class GetFullRoutingRequestQuery : IRequest<Response<Request>>
    {
        public int Id { get; set; }
    }
    public class GetFullRoutingRequestQueryHandler : IRequestHandler<GetFullRoutingRequestQuery, Response<Request>>
    {
        private readonly IRequestRepository _repository;
        public GetFullRoutingRequestQueryHandler(IRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Request>> Handle(GetFullRoutingRequestQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetRequestFullRoutingByIdAsync(query.Id);
            if (entity == null) return new($"Request Not Found (Id:{query.Id}).");
            return new Response<Request>(entity);
        }
    }
}
