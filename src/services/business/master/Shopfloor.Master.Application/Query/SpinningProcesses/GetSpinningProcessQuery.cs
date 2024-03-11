using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.SpinningProcesses
{
    public class GetSpinningProcessQuery : IRequest<Response<SpinningProcess>>
    {
        public int Id { get; set; }
    }
    public class GetSpinningProcessQueryHandler : IRequestHandler<GetSpinningProcessQuery, Response<SpinningProcess>>
    {
        private readonly ISpinningProcessRepository _repository;
        public GetSpinningProcessQueryHandler(ISpinningProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<SpinningProcess>> Handle(GetSpinningProcessQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SpinningProcess Not Found (Id:{query.Id}).");
            return new Response<SpinningProcess>(entity);
        }
    }
}
