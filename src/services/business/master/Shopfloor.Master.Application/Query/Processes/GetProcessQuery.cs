using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Processes
{
    public class GetProcessQuery : IRequest<Response<Process>>
    {
        public int Id { get; set; }
    }
    public class GetProcessQueryHandler : IRequestHandler<GetProcessQuery, Response<Process>>
    {
        private readonly IProcessRepository _repository;
        public GetProcessQueryHandler(IProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Process>> Handle(GetProcessQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetProcessInculdeLineMachine(query.Id);
            if (entity == null) return new ($"Process Not Found (Id:{query.Id}).");
            return new Response<Process>(entity);
        }
    }
}
