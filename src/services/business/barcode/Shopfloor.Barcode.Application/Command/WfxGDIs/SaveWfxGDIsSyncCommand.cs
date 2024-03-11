using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Barcode.Application.Command.WfxGDIs
{
    public class SaveWfxGDIsSyncCommand : IRequest<Response<bool>>
    {
        public ICollection<WfxGDI> Data { get; set; }
    }
    public class SaveWfxGDIsSyncCommandHandler : IRequestHandler<SaveWfxGDIsSyncCommand, Response<bool>>
    {
        private readonly IWfxGDIRepository _repository;
        public SaveWfxGDIsSyncCommandHandler(
            IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            _repository = scope.ServiceProvider.GetRequiredService<IWfxGDIRepository>();
        }

        public async Task<Response<bool>> Handle(SaveWfxGDIsSyncCommand request, CancellationToken cancellationToken)
        {
            var entities = request.Data;
            await _repository.SaveWfxGDISync(entities.ToList());
            return new Response<bool>(true);
        }
    }
}
