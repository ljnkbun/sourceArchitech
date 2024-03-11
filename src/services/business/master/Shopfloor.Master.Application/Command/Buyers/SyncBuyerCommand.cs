using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Buyers
{
    public class SyncBuyerCommand : IRequest<Response<bool>>
    {
        public List<WfxMasterDataDto> Data { get; set; }
    }

    public class SyncBuyerCommandHandler : IRequestHandler<SyncBuyerCommand, Response<bool>>
    {
        private readonly IBuyerRepository _repository;

        public SyncBuyerCommandHandler(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<IBuyerRepository>();
        }

        public async Task<Response<bool>> Handle(SyncBuyerCommand command, CancellationToken cancellationToken)
        {
            if (command.Data == null || command.Data.Count == 0) return new Response<bool>(true);
            var entities = await _repository.GetAllAsync();
            var newEntities = GetNewEntities(entities.ToList(), command.Data);
            var updateEntities = GetUpdateEntities(entities.ToList(), command.Data);

            if (newEntities.Count > 0)
            {
                await _repository.AddRangeAsync(newEntities);
            }

            if (updateEntities.Count > 0)
            {
                await _repository.UpdateRangeAsync(updateEntities);
            }

            return new Response<bool>(true);
        }
        private List<Buyer> GetNewEntities(List<Buyer> entities, List<WfxMasterDataDto> input)
        {
            return input.Where(x => entities.Count == 0 || entities.All(r => r.WFXBuyerId != x.Value))
                .Select(x => new Buyer
                {
                    WFXBuyerId = x.Value,
                    Name = x.Text,
                }).ToList();
        }

        private List<Buyer> GetUpdateEntities(List<Buyer> entities, List<WfxMasterDataDto> input)
        {
            var changes = entities.Where(x => input.Any(r => r.Value == x.WFXBuyerId && IsChanged(x, r)));
            var lstEntities = new List<Buyer>();
            foreach (var r in changes)
            {
                var ent = input.FirstOrDefault(x => x.Value == r.WFXBuyerId);
                r.WFXBuyerId = ent.Value;
                r.Name = ent.Text;
                lstEntities.Add(r);
            }
            return lstEntities;
        }

        private bool IsChanged(Buyer buyer, WfxMasterDataDto wfxBuyer)
        {
            var properties = new Dictionary<string, string>();
            properties.Add(nameof(buyer.WFXBuyerId), nameof(wfxBuyer.Value));
            properties.Add(nameof(buyer.Name), nameof(wfxBuyer.Text));
            foreach (var pt in properties)
            {
                var val = buyer.GetType().GetProperty(pt.Key)?.GetValue(buyer);
                var valCompare = wfxBuyer.GetType().GetProperty(pt.Value)?.GetValue(wfxBuyer);
                if (val == null && valCompare == null)
                    continue;
                if ((val == null && valCompare != null) || (val != null && valCompare == null))
                    return true;
                if (val?.Equals(valCompare) != true)
                    return true;
            }
            return false;
        }
    }
}
