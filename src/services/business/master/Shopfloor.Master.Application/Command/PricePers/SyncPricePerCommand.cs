using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.PricePers;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.PricePers
{
    public class SyncPricePerCommand : IRequest<Response<bool>>
    {
        public List<PricePerWFXModel> Data { get; set; }
    }
    public class SyncPricePerCommandHandler : IRequestHandler<SyncPricePerCommand, Response<bool>>
    {
        private readonly IPricePerRepository _repository;
        public SyncPricePerCommandHandler(IPricePerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(SyncPricePerCommand command, CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllAsync();
            var newEntities = GetNewEntities(entities, command.Data);
            var updateEntities = GetUpdateEntities(entities, command.Data);

            if (newEntities.Count > 0) { await _repository.AddRangeAsync(newEntities); }
            if (updateEntities.Count > 0) { await _repository.UpdateRangeAsync(updateEntities); }

            return new Response<bool>(true);
        }

        private List<PricePer> GetNewEntities(IReadOnlyList<PricePer> entities, List<PricePerWFXModel> input)
        {
            var entites = new List<PricePer>();
            // handle logic, mapping
            return entites;
        }

        private List<PricePer> GetUpdateEntities(IReadOnlyList<PricePer> entities, List<PricePerWFXModel> input)
        {
            var entites = new List<PricePer>();
            // handle logic, mapping
            return entites;
        }
    }
}
