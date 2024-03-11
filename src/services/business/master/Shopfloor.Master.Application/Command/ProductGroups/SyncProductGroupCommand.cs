using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroups
{
    public class SyncProductGroupCommand : IRequest<Response<bool>>
    {
        public List<WfxMasterDataDto> Data { get; set; }
    }
    public class SyncProductGroupCommandHandler : IRequestHandler<SyncProductGroupCommand, Response<bool>>
    {
        private readonly IProductGroupRepository _repository;
        public SyncProductGroupCommandHandler(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<IProductGroupRepository>();
        }
        public async Task<Response<bool>> Handle(SyncProductGroupCommand command, CancellationToken cancellationToken)
        {
            if (command.Data == null || command.Data.Count == 0) return new Response<bool>(true);
            var entities = await _repository.GetAllAsync();
            var newEntities = GetNewEntities(entities.ToList(), command.Data);
            var updateEntities = GetUpdateEntities(entities.ToList(), command.Data);

            if (newEntities.Count > 0) { await _repository.AddRangeAsync(newEntities); }
            if (updateEntities.Count > 0) { await _repository.UpdateRangeAsync(updateEntities); }

            return new Response<bool>(true);
        }

        private List<ProductGroup> GetNewEntities(List<ProductGroup> entities, List<WfxMasterDataDto> input)
        {
            return input.Where(x => entities.Count == 0 || !entities.Any(r => r.Code == x.Value))
                .Select(x => new ProductGroup(x.Value, x.Text)).ToList();
        }

        private List<ProductGroup> GetUpdateEntities(List<ProductGroup> entities, List<WfxMasterDataDto> input)
        {
            var changeds = entities.Where(x => input.Any(r => r.Value == x.Code && r.Text != x.Name));
            var entites = new List<ProductGroup>();
            foreach (var r in changeds)
            {
                var ent = input.FirstOrDefault(x => x.Value == r.Code);
                r.Name = ent.Text;
                entites.Add(r);
            }
            return entites;
        }
    }
}
