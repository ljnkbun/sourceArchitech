using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBackgroundStyles
{
    public class DeleteWeavingBackgroundStyleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingBackgroundStyleCommandHandler : IRequestHandler<DeleteWeavingBackgroundStyleCommand, Response<int>>
    {
        private readonly IWeavingBackgroundStyleRepository _repository;
        public DeleteWeavingBackgroundStyleCommandHandler(IWeavingBackgroundStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingBackgroundStyleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Shape Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
