using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.PaymentTerms
{
    public class GetPaymentTermQuery : IRequest<Response<PaymentTerm>>
    {
        public int Id { get; set; }
    }
    public class GetPaymentTermQueryHandler : IRequestHandler<GetPaymentTermQuery, Response<PaymentTerm>>
    {
        private readonly IPaymentTermRepository _repository;
        public GetPaymentTermQueryHandler(IPaymentTermRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<PaymentTerm>> Handle(GetPaymentTermQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"PaymentTerm Not Found (Id:{query.Id}).");
            return new Response<PaymentTerm>(entity);
        }
    }
}
