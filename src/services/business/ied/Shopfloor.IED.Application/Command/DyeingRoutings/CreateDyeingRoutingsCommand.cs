using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingRoutings
{
    public class CreateDyeingRoutingsCommand : IRequest<Response<bool>>
    {
        public int DyeingIEDId { get; set; }
        public virtual ICollection<DyeingRoutingModel> DyeingRoutings { get; set; }
    }
    public class CreateDyeingRoutingsCommandHandler : IRequestHandler<CreateDyeingRoutingsCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IDyeingRoutingRepository _repository;
        public CreateDyeingRoutingsCommandHandler(IMapper mapper, IDyeingRoutingRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateDyeingRoutingsCommand request, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<DyeingRouting>>(request.DyeingRoutings);
            if (entities == null || !entities.Any())
                return new Response<bool>(false);

            foreach (var entity in entities)
            {
                entity.DyeingIEDId = request.DyeingIEDId;
            }
            bool result = await _repository.AddRangeAsync(entities);
            return new Response<bool>(result);
        }
    }
}
