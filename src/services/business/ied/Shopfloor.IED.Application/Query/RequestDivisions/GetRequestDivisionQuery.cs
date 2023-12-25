using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.RequestDivisions
{
    public class GetRequestDivisionQuery : IRequest<Response<RequestDivision>>
    {
        public int Id { get; set; }
    }
    public class GetRequestDivisionQueryHandler : IRequestHandler<GetRequestDivisionQuery, Response<RequestDivision>>
    {
        private readonly IRequestDivisionRepository _repository;
        public GetRequestDivisionQueryHandler(IRequestDivisionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<RequestDivision>> Handle(GetRequestDivisionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetRequestDivisionByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"RequestDivision Not Found (Id:{query.Id}).");
            return new Response<RequestDivision>(entity);
        }
    }
}
