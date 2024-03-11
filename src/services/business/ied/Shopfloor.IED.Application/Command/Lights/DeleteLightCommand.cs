using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Lights
{
    public class DeleteLightCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLightCommandHandler : IRequestHandler<DeleteLightCommand, Response<int>>
    {
        private readonly ILightRepository _repository;
        public DeleteLightCommandHandler(ILightRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLightCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Light Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
