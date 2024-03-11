using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.DyeingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingRoutings
{
    public class UpdateDyeingRoutingsCommand : IRequest<Response<int>>
    {
        public int DyeingIEDId { get; set; }
        public virtual ICollection<DyeingRoutingModel> DyeingRoutings { get; set; }
    }
    public class UpdateDyeingRoutingsCommandHandler : IRequestHandler<UpdateDyeingRoutingsCommand, Response<int>>
    {
        private readonly IDyeingRoutingRepository _repository;
        private readonly IMapper _mapper;
        public UpdateDyeingRoutingsCommandHandler(IDyeingRoutingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateDyeingRoutingsCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<DyeingRouting>>(command.DyeingRoutings);
            foreach (var entity in entities)
            {
                entity.DyeingIEDId = command.DyeingIEDId;
            }
            await _repository.UpdateDyeingRoutingsAsync(command.DyeingIEDId, entities);
            return new Response<int>(command.DyeingIEDId);
        }
    }
}
