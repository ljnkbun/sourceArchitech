using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Divisions
{
    public class GetDivisionQuery : IRequest<Response<Division>>
    {
        public int Id { get; set; }
    }
    public class GetDivisionQueryHandler : IRequestHandler<GetDivisionQuery, Response<Division>>
    {
        private readonly IDivisionRepository _repository;
        public GetDivisionQueryHandler(IDivisionRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Division>> Handle(GetDivisionQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Division Not Found (Id: {query.Id}).");
            return new Response<Division>(entity);
        }
    }
}
