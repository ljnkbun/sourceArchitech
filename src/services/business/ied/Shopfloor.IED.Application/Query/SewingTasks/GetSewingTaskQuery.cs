using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingTasks
{
    public class GetSewingTaskQuery : IRequest<Response<SewingTask>>
    {
        public int Id { get; set; }
    }
    public class GetSewingTaskQueryHandler : IRequestHandler<GetSewingTaskQuery, Response<SewingTask>>
    {
        private readonly ISewingTaskRepository _repository;
        public GetSewingTaskQueryHandler(ISewingTaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SewingTask>> Handle(GetSewingTaskQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"SewingTask Not Found (Id:{query.Id}).");
            return new Response<SewingTask>(entity);
        }
    }
}
