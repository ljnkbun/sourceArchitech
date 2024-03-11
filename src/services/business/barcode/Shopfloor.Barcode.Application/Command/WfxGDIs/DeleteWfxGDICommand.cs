using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Barcode.Domain.Interfaces;

namespace Shopfloor.Barcode.Application.Command.WfxGDIs
{
    public class DeleteWfxGDICommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWfxGDICommandHandler : IRequestHandler<DeleteWfxGDICommand, Response<int>>
    {
        private readonly IWfxGDIRepository _repository;
        public DeleteWfxGDICommandHandler(IWfxGDIRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWfxGDICommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WfxGDI Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
