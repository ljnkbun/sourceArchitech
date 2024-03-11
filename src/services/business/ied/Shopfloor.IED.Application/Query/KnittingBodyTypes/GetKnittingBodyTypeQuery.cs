using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.KnittingBodyTypes
{
    public class GetKnittingBodyTypeQuery : IRequest<Response<KnittingBodyType>>
    {
        public int Id { get; set; }
    }
    public class GetKnittingBodyTypeQueryHandler : IRequestHandler<GetKnittingBodyTypeQuery, Response<KnittingBodyType>>
    {
        private readonly IKnittingBodyTypeRepository _repository;
        public GetKnittingBodyTypeQueryHandler(IKnittingBodyTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<KnittingBodyType>> Handle(GetKnittingBodyTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"KnittingBodyType Not Found (Id:{query.Id}).");
            return new Response<KnittingBodyType>(entity);
        }
    }
}
