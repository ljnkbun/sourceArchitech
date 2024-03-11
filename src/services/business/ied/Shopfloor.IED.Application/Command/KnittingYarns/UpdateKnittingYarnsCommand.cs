using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Application.Models.KnittingYarns;
using Shopfloor.IED.Domain.Entities;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingYarns
{
    public class UpdateKnittingYarnsCommand : IRequest<Response<int>>
    {
        public int KnittingIEDId { get; set; }
        public List<KnittingYarnModel> KnittingYarnModels { get; set; }
    }
    public class UpdateKnittingYarnsCommandHandler : IRequestHandler<UpdateKnittingYarnsCommand, Response<int>>
    {
        private readonly IKnittingYarnRepository _repository;
        private readonly IMapper _mapper;
        public UpdateKnittingYarnsCommandHandler(IKnittingYarnRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateKnittingYarnsCommand command, CancellationToken cancellationToken)
        {
            var entities = _mapper.Map<List<KnittingYarn>>(command.KnittingYarnModels);
            foreach (var entity in entities)
            {
                entity.KnittingIEDId = command.KnittingIEDId;
            }
            await _repository.UpdateKnittingYarnsAsync(command.KnittingIEDId, entities);
            return new Response<int>(command.KnittingIEDId);
        }
    }
}
