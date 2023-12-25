using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBackgrounStyles
{
    public class DeleteWeavingBackgrounStyleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingBackgrounStyleCommandHandler : IRequestHandler<DeleteWeavingBackgrounStyleCommand, Response<int>>
    {
        private readonly IWeavingBackgrounStyleRepository _repository;
        public DeleteWeavingBackgrounStyleCommandHandler(IWeavingBackgrounStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingBackgrounStyleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"Shape Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
