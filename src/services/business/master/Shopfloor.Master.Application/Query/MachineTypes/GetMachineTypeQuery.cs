using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Query.MachineTypes
{
    public class GetMachineTypeQuery : IRequest<Response<MachineType>>
    {
        public int Id { get; set; }
    }
    public class GetMachineTypeQueryHandler : IRequestHandler<GetMachineTypeQuery, Response<MachineType>>
    {
        private readonly IMachineTypeRepository _repository;
        public GetMachineTypeQueryHandler(IMachineTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<MachineType>> Handle(GetMachineTypeQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"MachineType Not Found (Id:{query.Id}).");
            return new Response<MachineType>(entity);
        }
    }
}
