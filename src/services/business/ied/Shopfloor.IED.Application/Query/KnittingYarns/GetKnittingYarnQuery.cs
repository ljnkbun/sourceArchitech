using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingYarns
{
    public class GetKnittingYarnQuery : IRequest<Response<KnittingYarn>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingYarnQueryHandler : IRequestHandler<GetKnittingYarnQuery, Response<KnittingYarn>>
    {
        private readonly IKnittingYarnRepository _repository;
        public GetKnittingYarnQueryHandler(IKnittingYarnRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingYarn>> Handle(GetKnittingYarnQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingYarn Not Found (Id:{query.Id}).");
            return new Response<KnittingYarn>(entity);
        }
    }
}
