using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Currencies
{
    public class GetCurrencyQuery : IRequest<Response<Currency>>
    {
        public int Id { get; set; }
    }
    public class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, Response<Currency>>
    {
        private readonly ICurrencyRepository _repository;
        public GetCurrencyQueryHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Currency>> Handle(GetCurrencyQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Currency Not Found (Id:{query.Id}).");
            return new Response<Currency>(entity);
        }
    }
}
