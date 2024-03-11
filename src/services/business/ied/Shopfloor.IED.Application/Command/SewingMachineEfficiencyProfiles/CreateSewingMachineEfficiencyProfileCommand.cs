using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingMachineEfficiencyProfiles
{
    public class CreateSewingMachineEfficiencyProfileCommand : IRequest<Response<int>>
    {
        public int SewingEfficiencyProfileId { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
    }

    public class CreateSewingMachineEfficiencyProfileCommandHandler : IRequestHandler<CreateSewingMachineEfficiencyProfileCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingMachineEfficiencyProfileRepository _repository;

        public CreateSewingMachineEfficiencyProfileCommandHandler(IMapper mapper,
            ISewingMachineEfficiencyProfileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingMachineEfficiencyProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.SewingMachineEfficiencyProfile>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}