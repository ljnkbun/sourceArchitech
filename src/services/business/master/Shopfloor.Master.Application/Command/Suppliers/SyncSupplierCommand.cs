using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Core.Models.Responses;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Suppliers
{
    public class SyncSupplierCommand : IRequest<Response<bool>>
    {
        public List<WfxMasterDataDto> Data { get; set; }
    }

    public class SyncSupplierCommandHandler : IRequestHandler<SyncSupplierCommand, Response<bool>>
    {
        private readonly ISupplierRepository _repository;

        public SyncSupplierCommandHandler(IServiceProvider serviceProvider
        )
        {
            var scope = serviceProvider.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<ISupplierRepository>();
        }

        public async Task<Response<bool>> Handle(SyncSupplierCommand command, CancellationToken cancellationToken)
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
        private List<Supplier> GetNewEntities(List<Supplier> entities, List<WfxMasterDataDto> input)
        {
            return input.Where(x => entities.Count == 0 || entities.All(r => r.WFXSupplierId != x.Value))
                .Select(x => new Supplier
                {
                    WFXSupplierId = x.Value,
                    Name = x.Text,
                }).ToList();
        }

        private List<Supplier> GetUpdateEntities(List<Supplier> entities, List<WfxMasterDataDto> input)
        {
            var changes = entities.Where(x => input.Any(r => r.Value == x.WFXSupplierId && IsChanged(x, r)));
            var lstEntities = new List<Supplier>();
            foreach (var r in changes)
            {
                var ent = input.FirstOrDefault(x => x.Value == r.WFXSupplierId);
                r.WFXSupplierId = ent.Value;
                r.Name = ent.Text;
                lstEntities.Add(r);
            }
            return lstEntities;
        }

        private bool IsChanged(Supplier supplier, WfxMasterDataDto wfxSupplier)
        {
            var properties = new Dictionary<string, string>();
            properties.Add(nameof(supplier.WFXSupplierId), nameof(wfxSupplier.Value));
            properties.Add(nameof(supplier.Name), nameof(wfxSupplier.Text));
            foreach (var pt in properties)
            {
                var val = supplier.GetType().GetProperty(pt.Key)?.GetValue(supplier);
                var valCompare = wfxSupplier.GetType().GetProperty(pt.Value)?.GetValue(wfxSupplier);
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
