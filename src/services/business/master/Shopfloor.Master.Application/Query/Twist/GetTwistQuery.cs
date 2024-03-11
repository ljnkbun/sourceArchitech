using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Twists
{
    public class GetTwistQuery : IRequest<Response<Twist>>
    {
        public int Id { get; set; }
    }
    public class GetTwistQueryHandler : IRequestHandler<GetTwistQuery, Response<Twist>>
    {
        private readonly ITwistRepository _repository;
        public GetTwistQueryHandler(ITwistRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Twist>> Handle(GetTwistQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Twist Not Found (Id:{query.Id}).");
            return new Response<Twist>(entity);
        }
    }
}
