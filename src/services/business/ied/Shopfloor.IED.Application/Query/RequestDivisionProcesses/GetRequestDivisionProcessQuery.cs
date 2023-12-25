using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestDivisionProcesses
{
    public class GetRequestDivisionProcessQuery : IRequest<Response<RequestDivisionProcess>>
    {
        public int Id { get; set; }
    }
    public class GetRequestDivisionProcessQueryHandler : IRequestHandler<GetRequestDivisionProcessQuery, Response<RequestDivisionProcess>>
    {
        private readonly IRequestDivisionProcessRepository _repository;
        public GetRequestDivisionProcessQueryHandler(IRequestDivisionProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<RequestDivisionProcess>> Handle(GetRequestDivisionProcessQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetRequestDivisionProcessByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"RequestDivisionProcess Not Found (Id:{query.Id}).");
            return new Response<RequestDivisionProcess>(entity);
        }
    }
}
