using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.SewingRoutingBOLs;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingRoutingBOLs
{
    public class UpdateSewingRoutingBOLsCommand : IRequest<Response<int>>
    {
        public int SewingRoutingId { get; set; }
        public virtual ICollection<SewingRoutingBOLModel> SewingRoutingBOLs { get; set; }
    }
    public class UpdateSewingRoutingBOLsCommandHandler : IRequestHandler<UpdateSewingRoutingBOLsCommand, Response<int>>
    {
        private readonly ISewingRoutingBOLRepository _repository;
        private readonly IMapper _mapper;
        public UpdateSewingRoutingBOLsCommandHandler(ISewingRoutingBOLRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateSewingRoutingBOLsCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<SewingRoutingBOL>>(command.SewingRoutingBOLs);
            foreach (var entity in entities)
            {
                entity.SewingRoutingId = command.SewingRoutingId;
                entity.Id = 0;
            }
            await _repository.UpdateSewingRoutingBOLsAsync(command.SewingRoutingId, entities);
            return new Response<int>(command.SewingRoutingId);
        }
    }
}
