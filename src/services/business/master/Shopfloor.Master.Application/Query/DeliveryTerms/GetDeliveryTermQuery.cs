using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.DeliveryTerms
{
    public class GetDeliveryTermQuery : IRequest<Response<DeliveryTerm>>
    {
        public int Id { get; set; }
    }
    public class GetDeliveryTermQueryHandler : IRequestHandler<GetDeliveryTermQuery, Response<DeliveryTerm>>
    {
        private readonly IDeliveryTermRepository _repository;
        public GetDeliveryTermQueryHandler(IDeliveryTermRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<DeliveryTerm>> Handle(GetDeliveryTermQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"DeliveryTerm Not Found (Id:{query.Id}).");
            return new Response<DeliveryTerm>(entity);
        }
    }
}
