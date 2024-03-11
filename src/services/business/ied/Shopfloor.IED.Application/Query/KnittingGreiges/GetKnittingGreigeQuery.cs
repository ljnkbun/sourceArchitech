using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingGreiges
{
    public class GetKnittingGreigeQuery : IRequest<Response<KnittingGreige>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingGreigeQueryHandler : IRequestHandler<GetKnittingGreigeQuery, Response<KnittingGreige>>
    {
        private readonly IKnittingGreigeRepository _repository;
        public GetKnittingGreigeQueryHandler(IKnittingGreigeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingGreige>> Handle(GetKnittingGreigeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingGreige Not Found (Id:{query.Id}).");
            return new Response<KnittingGreige>(entity);
        }
    }
}
