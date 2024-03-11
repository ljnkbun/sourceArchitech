using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRoutings
{
    public class UpdateWeavingRoutingsCommand : IRequest<Response<int>>
    {
        public int WeavingIEDId { get; set; }
        public virtual ICollection<CreateWeavingRoutingCommand> WeavingRoutings { get; set; }
    }

    public class UpdateWeavingRoutingsCommandHandler : IRequestHandler<UpdateWeavingRoutingsCommand, Response<int>>
    {
        private readonly IWeavingRoutingRepository _repository;
        private readonly IMapper _mapper;

        public UpdateWeavingRoutingsCommandHandler(IWeavingRoutingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateWeavingRoutingsCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<WeavingRouting>>(command.WeavingRoutings);
            foreach (var entity in entities)
            {
                entity.WeavingIEDId = command.WeavingIEDId;
            }
            await _repository.UpdateWeavingRoutingsAsync(command.WeavingIEDId, entities);
            return new Response<int>(command.WeavingIEDId);
        }
    }
}