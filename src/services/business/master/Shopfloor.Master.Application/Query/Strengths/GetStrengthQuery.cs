using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Strengths
{
    public class GetStrengthQuery : IRequest<Response<Strength>>
    {
        public int Id { get; set; }
    }
    public class GetStrengthQueryHandler : IRequestHandler<GetStrengthQuery, Response<Strength>>
    {
        private readonly IStrengthRepository _repository;
        public GetStrengthQueryHandler(IStrengthRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Strength>> Handle(GetStrengthQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Strength Not Found (Id:{query.Id}).");
            return new Response<Strength>(entity);
        }
    }
}
