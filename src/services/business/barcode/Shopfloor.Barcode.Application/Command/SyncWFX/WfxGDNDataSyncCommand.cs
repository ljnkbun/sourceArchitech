using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.SyncWFX
{
    public class WfxGDNDataSyncCommand : IRequest<Response<bool>>
    {
        public List<WfxGDN> Data { get; set; }
    }
    public class WfxGDNDataSyncCommandHandler : IRequestHandler<WfxGDNDataSyncCommand, Response<bool>>
    {
        private readonly IWfxGDNRepository _repository;
        public WfxGDNDataSyncCommandHandler(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<IWfxGDNRepository>();
        }
        public async Task<Response<bool>> Handle(WfxGDNDataSyncCommand command, CancellationToken cancellationToken)
        {
            await _repository.SaveWfxGDNSync(command.Data.ToList());
            return new Response<bool>(true);
        }

    }
}
