using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingRoutings;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRoutings
{
    public class UpdateSewingRoutingsCommand : IRequest<Response<int>>
    {
        public int SewingIEDId { get; set; }
        public virtual ICollection<SewingRoutingModel> SewingRoutings { get; set; }
    }
    public class UpdateSewingRoutingsCommandHandler : IRequestHandler<UpdateSewingRoutingsCommand, Response<int>>
    {
        private readonly ISewingRoutingRepository _repository;
        private readonly IMapper _mapper;
        public UpdateSewingRoutingsCommandHandler(ISewingRoutingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingRoutingsCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<SewingRouting>>(command.SewingRoutings);
            foreach (var entity in entities)
            {
                entity.SewingIEDId = command.SewingIEDId;
            }
            await _repository.UpdateSewingRoutingsAsync(command.SewingIEDId, entities);
            return new Response<int>(command.SewingIEDId);
        }
    }
}
