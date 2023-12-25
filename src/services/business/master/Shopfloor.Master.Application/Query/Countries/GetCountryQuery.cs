using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Countries
{
    public class GetCountryQuery : IRequest<Response<Country>>
    {
        public int Id { get; set; }
    }
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, Response<Country>>
    {
        private readonly ICountryRepository _repository;
        public GetCountryQueryHandler(ICountryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Country>> Handle(GetCountryQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"Country Not Found (Id:{query.Id}).");
            return new Response<Country>(entity);
        }
    }
}
