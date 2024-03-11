using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingTypes
{
    public class GetKnittingTypeQuery : IRequest<Response<KnittingType>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingTypeQueryHandler : IRequestHandler<GetKnittingTypeQuery, Response<KnittingType>>
    {
        private readonly IKnittingTypeRepository _repository;
        public GetKnittingTypeQueryHandler(IKnittingTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingType>> Handle(GetKnittingTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingType Not Found (Id:{query.Id}).");
            return new Response<KnittingType>(entity);
        }
    }
}
