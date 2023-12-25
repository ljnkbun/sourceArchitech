using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestTypes
{
    public class GetRequestTypeQuery : IRequest<Response<RequestType>>
    {
        public int Id { get; set; }
    }
    public class GetRequestTypeQueryHandler : IRequestHandler<GetRequestTypeQuery, Response<RequestType>>
    {
        private readonly IRequestTypeRepository _repository;
        public GetRequestTypeQueryHandler(IRequestTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<RequestType>> Handle(GetRequestTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"RequestType Not Found (Id:{query.Id}).");
            return new Response<RequestType>(entity);
        }
    }
}
