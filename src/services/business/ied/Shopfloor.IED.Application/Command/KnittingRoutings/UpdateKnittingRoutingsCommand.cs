using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingRoutings
{
    public class UpdateKnittingRoutingsCommand : IRequest<Response<int>>
    {
        public int KnittingIEDId { get; set; }
        public List<KnittingRoutingModel> KnittingRoutingModels { get; set; }
    }
    public class UpdateKnittingRoutingsCommandHandler : IRequestHandler<UpdateKnittingRoutingsCommand, Response<int>>
    {
        private readonly IKnittingRoutingRepository _repository;
        private readonly IMapper _mapper;
        public UpdateKnittingRoutingsCommandHandler(IKnittingRoutingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateKnittingRoutingsCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<KnittingRouting>>(command.KnittingRoutingModels);
            foreach (var entity in entities)
            {
                entity.KnittingIEDId = command.KnittingIEDId;
            }
            await _repository.UpdateKnittingRoutingsAsync(command.KnittingIEDId, entities);
            return new Response<int>(command.KnittingIEDId);
        }
    }
}
