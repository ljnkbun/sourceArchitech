using AutoMapper;
using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Application.Models.Wfxs;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.ProductGroups
{
    public class SyncProductGroupCommand : IRequest<Response<bool>>
    {
        public List<WfxApiMasterData> Data { get; set; }
    }
    public class SyncProductGroupCommandHandler : IRequestHandler<SyncProductGroupCommand, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IProductGroupRepository _repository;
        public SyncProductGroupCommandHandler(IMapper mapper,
            IProductGroupRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
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

        private List<ProductGroup> GetNewEntities(List<ProductGroup> entities, List<WfxApiMasterData> input)
        {
            return input.Where(x => entities.Count == 0 || !entities.Any(r => r.Code == x.value))
                .Select(x => new ProductGroup(x.value, x.text)).ToList();
        }

        private List<ProductGroup> GetUpdateEntities(List<ProductGroup> entities, List<WfxApiMasterData> input)
        {
            var changeds = entities.Where(x => input.Any(r => r.value == x.Code && r.text != x.Name));
            var entites = new List<ProductGroup>();
            foreach (var r in changeds)
            {
                var ent = input.FirstOrDefault(x => x.value == r.Code);
                r.Name = ent.text;
                entites.Add(r);
            }
            return entites;
        }
    }
}
