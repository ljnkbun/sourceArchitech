using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.AccountGroups
{
    public class GetAccountGroupQuery : IRequest<Response<AccountGroup>>
    {
        public int Id { get; set; }
    }
    public class GetAccountGroupQueryHandler : IRequestHandler<GetAccountGroupQuery, Response<AccountGroup>>
    {
        private readonly IAccountGroupRepository _repository;
        public GetAccountGroupQueryHandler(IAccountGroupRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<AccountGroup>> Handle(GetAccountGroupQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"AccountGroup Not Found (Id:{query.Id}).");
            return new Response<AccountGroup>(entity);
        }
    }
}
