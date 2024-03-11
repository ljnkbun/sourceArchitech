using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingMachineEfficiencyProfiles
{
    public class GetSewingMachineEfficiencyProfileByMachineQuery : IRequest<Response<SewingMachineEfficiencyProfile>>
    {
        public int MachineId { get; set; }
    }

    public class GetSewingMachineEfficiencyProfileByMachineQueryHandler : IRequestHandler<GetSewingMachineEfficiencyProfileByMachineQuery, Response<SewingMachineEfficiencyProfile>>
    {
        private readonly ISewingMachineEfficiencyProfileRepository _repository;

        public GetSewingMachineEfficiencyProfileByMachineQueryHandler(ISewingMachineEfficiencyProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<SewingMachineEfficiencyProfile>> Handle(GetSewingMachineEfficiencyProfileByMachineQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByMachineAsync(query.MachineId);
            if (entity == null) return new($"SewingMachineEfficiencyProfile Not Found (MachineId:{query.MachineId}).");
            return new Response<SewingMachineEfficiencyProfile>(entity);
        }
    }
}