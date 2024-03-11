using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.WeavingRappoMarks
{
    public class GetWeavingRappoMarkQuery : IRequest<Response<WeavingRappoMark>>
    {
        public int Id { get; set; }
    }
    public class GetWeavingRappoMarkQueryHandler : IRequestHandler<GetWeavingRappoMarkQuery, Response<WeavingRappoMark>>
    {
        private readonly IWeavingRappoMarkRepository _repository;
        public GetWeavingRappoMarkQueryHandler(IWeavingRappoMarkRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<WeavingRappoMark>> Handle(GetWeavingRappoMarkQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"WeavingRappoMark Not Found (Id:{query.Id}).");
            return new Response<WeavingRappoMark>(entity);
        }
    }
}
