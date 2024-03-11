using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.WeavingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRoutings
{
    public class CreateWeavingRoutingsCommand : IRequest<Response<bool>>
    {
        public int WeavingIEDId { get; set; }
        public virtual ICollection<WeavingRoutingModel> WeavingRoutings { get; set; }
    }

    public class CreateWeavingRoutingsCommandHandler : IRequestHandler<CreateWeavingRoutingsCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IWeavingRoutingRepository _repository;

        public CreateWeavingRoutingsCommandHandler(IMapper mapper,
            IWeavingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateWeavingRoutingsCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<WeavingRouting>>(request.WeavingRoutings);
            if (entities == null || !entities.Any())
                return new Response<bool>(false);

            foreach (var entity in entities)
            {
                entity.WeavingIEDId = request.WeavingIEDId;
            }
            bool result = await _repository.AddRangeAsync(entities);
            return new Response<bool>(result);
        }
    }
}