using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Machines
{
    public class CreateMachineCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SerialNo { get; set; }
        public string Remarks { get; set; }
        public decimal? Capacity { get; set; }
        public int? FactoryId { get; set; }
        public int? ProcessId { get; set; }
        public string Gauge { get; set; }
        public string MachineDiameter { get; set; }
    }
    public class CreateMachineCommandHandler : IRequestHandler<CreateMachineCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IMachineRepository _repository;
        public CreateMachineCommandHandler(IMapper mapper,
            IMachineRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateMachineCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Machine>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
