using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.CountTypes
{
    public class GetCountTypeQuery : IRequest<Response<CountType>>
    {
        public int Id { get; set; }
    }
    public class GetCountTypeQueryHandler : IRequestHandler<GetCountTypeQuery, Response<CountType>>
    {
        private readonly ICountTypeRepository _repository;
        public GetCountTypeQueryHandler(ICountTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<CountType>> Handle(GetCountTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"CountType Not Found (Id:{query.Id}).");
            return new Response<CountType>(entity);
        }
    }
}
