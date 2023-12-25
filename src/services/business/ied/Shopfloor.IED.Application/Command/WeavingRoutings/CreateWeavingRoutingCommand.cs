using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRoutings
{
    public class CreateWeavingRoutingCommand : IRequest<Response<int>>
    {
        public int WeavingIEDId { get; set; }
        public int LineNumber { get; set; }
        public string WeavingProcess { get; set; }
        public string WeavingOperation { get; set; }
        public string MachineType { get; set; }
    }
    public class CreateWeavingRoutingCommandHandler : IRequestHandler<CreateWeavingRoutingCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRoutingRepository _repository;
        public CreateWeavingRoutingCommandHandler(IMapper mapper,
            IWeavingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWeavingRoutingCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<WeavingRouting>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
