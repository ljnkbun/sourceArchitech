using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.GroupNames
{
    public class GetGroupNameQuery : IRequest<Response<GroupName>>
    {
        public int Id { get; set; }
    }
    public class GetGroupNameQueryHandler : IRequestHandler<GetGroupNameQuery, Response<GroupName>>
    {
        private readonly IGroupNameRepository _repository;
        public GetGroupNameQueryHandler(IGroupNameRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<GroupName>> Handle(GetGroupNameQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) throw new ApiException($"GroupName Not Found (Id:{query.Id}).");
            return new Response<GroupName>(entity);
        }
    }
}
