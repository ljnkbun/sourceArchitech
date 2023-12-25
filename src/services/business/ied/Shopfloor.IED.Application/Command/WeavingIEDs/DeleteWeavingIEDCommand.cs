using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingIEDs
{
    public class DeleteWeavingIEDCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingIEDCommandHandler : IRequestHandler<DeleteWeavingIEDCommand, Response<int>>
    {
        private readonly IWeavingIEDRepository _repository;
        public DeleteWeavingIEDCommandHandler(IWeavingIEDRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingIEDCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"WeavingIED Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
