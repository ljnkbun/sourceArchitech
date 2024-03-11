using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Staples
{
    public class GetStapleQuery : IRequest<Response<Staple>>
    {
        public int Id { get; set; }
    }
    public class GetStapleQueryHandler : IRequestHandler<GetStapleQuery, Response<Staple>>
    {
        private readonly IStapleRepository _repository;
        public GetStapleQueryHandler(IStapleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Staple>> Handle(GetStapleQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Staple Not Found (Id:{query.Id}).");
            return new Response<Staple>(entity);
        }
    }
}
