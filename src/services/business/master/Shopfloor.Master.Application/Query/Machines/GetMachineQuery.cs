using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.Machines
{
    public class GetMachineQuery : IRequest<Response<Machine>>
    {
        public int Id { get; set; }
    }
    public class GetMachineQueryHandler : IRequestHandler<GetMachineQuery, Response<Machine>>
    {
        private readonly IMachineRepository _repository;
        public GetMachineQueryHandler(IMachineRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<Machine>> Handle(GetMachineQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"Machine Not Found (Id:{query.Id}).");
            return new Response<Machine>(entity);
        }
    }
}
