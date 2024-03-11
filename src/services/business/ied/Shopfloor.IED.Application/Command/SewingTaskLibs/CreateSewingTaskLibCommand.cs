using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingTaskLibs
{
    public class CreateSewingTaskLibCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public decimal? ManualTMU { get; set; }
        public decimal? MachineTMU { get; set; }
        public decimal? BundleTMU { get; set; }
        public decimal TotalTMU { get; set; }
        public decimal? BundleTime { get; set; }
        public TaskType TaskType { get; set; }
        public int? SewingMachineEfficiencyProfileId { get; set; }
        public int? SewingBundleId { get; set; }
    }
    public class CreateSewingTaskLibCommandHandler : IRequestHandler<CreateSewingTaskLibCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ISewingTaskLibRepository _repository;
        public CreateSewingTaskLibCommandHandler(IMapper mapper,
            ISewingTaskLibRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSewingTaskLibCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<SewingTaskLib>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
