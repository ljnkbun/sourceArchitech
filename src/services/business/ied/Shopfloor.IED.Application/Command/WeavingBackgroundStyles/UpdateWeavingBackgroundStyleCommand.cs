using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBackgroundStyles
{
    public class UpdateWeavingBackgroundStyleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateWeavingBackgroundStyleCommandHandler : IRequestHandler<UpdateWeavingBackgroundStyleCommand, Response<int>>
    {
        private readonly IWeavingBackgroundStyleRepository _repository;
        public UpdateWeavingBackgroundStyleCommandHandler(IWeavingBackgroundStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingBackgroundStyleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingBackgroundStyle Not Found.");

            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
