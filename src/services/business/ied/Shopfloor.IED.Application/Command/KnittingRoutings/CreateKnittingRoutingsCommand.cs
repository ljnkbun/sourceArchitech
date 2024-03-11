using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingRoutings
{
    public class CreateKnittingRoutingsCommand : IRequest<Response<bool>>
    {
        public int KnittingIEDId { get; set; }
        public List<KnittingRoutingModel> KnittingRoutingModels { get; set; }
    }
    public class CreateKnittingRoutingsCommandHandler : IRequestHandler<CreateKnittingRoutingsCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IKnittingRoutingRepository _repository;
        public CreateKnittingRoutingsCommandHandler(IMapper mapper,
            IKnittingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateKnittingRoutingsCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<KnittingRouting>>(request.KnittingRoutingModels);
            if(entities == null || !entities.Any())
                return new Response<bool>(false);

            foreach (var entity in entities)
            {
                entity.KnittingIEDId = request.KnittingIEDId;
            }
            bool result = await _repository.AddRangeAsync(entities);
            return new Response<bool>(result);
        }
    }
}
