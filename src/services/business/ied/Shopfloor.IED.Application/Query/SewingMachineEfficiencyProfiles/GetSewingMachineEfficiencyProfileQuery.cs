using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Query.SewingMachineEfficiencyProfiles
{
    public class GetSewingMachineEfficiencyProfileQuery : IRequest<Response<Domain.Entities.SewingMachineEfficiencyProfile>>
    {
        public int Id { get; set; }
    }

    public class GetSewingMachineEfficiencyProfileQueryHandler : IRequestHandler<GetSewingMachineEfficiencyProfileQuery, Response<Domain.Entities.SewingMachineEfficiencyProfile>>
    {
        private readonly ISewingMachineEfficiencyProfileRepository _repository;

        public GetSewingMachineEfficiencyProfileQueryHandler(ISewingMachineEfficiencyProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<Domain.Entities.SewingMachineEfficiencyProfile>> Handle(GetSewingMachineEfficiencyProfileQuery query, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity == null) return new($"SewingMachineEfficiencyProfile Not Found (Id:{query.Id}).");
            return new Response<Domain.Entities.SewingMachineEfficiencyProfile>(entity);
        }
    }
}