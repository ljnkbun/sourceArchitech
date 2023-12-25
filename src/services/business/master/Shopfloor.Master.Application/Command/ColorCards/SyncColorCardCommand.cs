using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.ColorCards;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ColorCards
{
    public class SyncColorCardCommand : IRequest<Response<bool>>
    {
        public List<ColorCardWFXModel> Data { get; set; }
    }
    public class SyncColorCardCommandHandler : IRequestHandler<SyncColorCardCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IColorCardRepository _repository;
        public SyncColorCardCommandHandler(IMapper mapper,
            IColorCardRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(SyncColorCardCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            var newEntities = GetNewEntities(entities, command.Data);
            var updateEntities = GetUpdateEntities(entities, command.Data);

            if(newEntities.Count> 0) { await _repository.AddRangeAsync(newEntities); }
            if(updateEntities.Count> 0) { await _repository.UpdateRangeAsync(updateEntities); }

            return new Response<bool>(true);
        }

        private List<ColorCard> GetNewEntities(IReadOnlyList<ColorCard> entities, List<ColorCardWFXModel> input)
        {
            var entites = new List<ColorCard>();
            // handle logic, mapping
            return entites;
        }

        private List<ColorCard> GetUpdateEntities(IReadOnlyList<ColorCard> entities, List<ColorCardWFXModel> input)
        {
            var entites = new List<ColorCard>();
            // handle logic, mapping
            return entites;
        }
    }
}
