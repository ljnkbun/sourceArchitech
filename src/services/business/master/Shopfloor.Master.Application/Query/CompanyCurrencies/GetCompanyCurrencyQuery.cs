using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CompanyCurrencies
{
    public class GetCompanyCurrencyQuery : IRequest<Response<CompanyCurrency>>
    {
        public int Id { get; set; }
    }
    public class GetCompanyCurrencyQueryHandler : IRequestHandler<GetCompanyCurrencyQuery, Response<CompanyCurrency>>
    {
        private readonly ICompanyCurrencyRepository _repository;
        public GetCompanyCurrencyQueryHandler(ICompanyCurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<CompanyCurrency>> Handle(GetCompanyCurrencyQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"CompanyCurrency Not Found (Id:{query.Id}).");
            return new Response<CompanyCurrency>(entity);
        }
    }
}
