using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.ProcessTasks
{
    public class GetProcessTaskQuery : IRequest<Response<ProcessTask>>
    {
        public int Id { get; set; }
    }
    public class GetProcessTaskQueryHandler : IRequestHandler<GetProcessTaskQuery, Response<ProcessTask>>
    {
        private readonly IProcessTaskRepository _repository;
        public GetProcessTaskQueryHandler(IProcessTaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<ProcessTask>> Handle(GetProcessTaskQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"ProcessTask Not Found (Id:{query.Id}).");
            return new Response<ProcessTask>(entity);
        }
    }
}
