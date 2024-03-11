using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Structures
{
    public class GetStructureQuery : IRequest<Response<Structure>>
    {
        public int Id { get; set; }
    }
    public class GetStructureQueryHandler : IRequestHandler<GetStructureQuery, Response<Structure>>
    {
        private readonly IStructureRepository _repository;
        public GetStructureQueryHandler(IStructureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Structure>> Handle(GetStructureQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Structure Not Found (Id:{query.Id}).");
            return new Response<Structure>(entity);
        }
    }
}
