using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.Requests
{
    public class GetRequestQuery : IRequest<Response<Request>>
    {
        public int Id { get; set; }
    }
    public class GetRequestQueryHandler : IRequestHandler<GetRequestQuery, Response<Request>>
    {
        private readonly IRequestRepository _repository;
        public GetRequestQueryHandler(IRequestRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Request>> Handle(GetRequestQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetRequestByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Request Not Found (Id:{query.Id}).");
            return new Response<Request>(entity);
        }
    }
}
