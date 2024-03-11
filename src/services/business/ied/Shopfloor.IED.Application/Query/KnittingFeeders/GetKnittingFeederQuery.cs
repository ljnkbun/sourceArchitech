using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingFeeders
{
    public class GetKnittingFeederQuery : IRequest<Response<KnittingFeeder>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingFeederQueryHandler : IRequestHandler<GetKnittingFeederQuery, Response<KnittingFeeder>>
    {
        private readonly IKnittingFeederRepository _repository;
        public GetKnittingFeederQueryHandler(IKnittingFeederRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingFeeder>> Handle(GetKnittingFeederQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingFeeder Not Found (Id:{query.Id}).");
            return new Response<KnittingFeeder>(entity);
        }
    }
}
