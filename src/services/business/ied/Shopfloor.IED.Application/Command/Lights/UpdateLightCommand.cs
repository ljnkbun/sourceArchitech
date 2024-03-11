using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Lights
{
    public class UpdateLightCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateLightCommandHandler : IRequestHandler<UpdateLightCommand, Response<int>>
    {
        private readonly ILightRepository _repository;
        public UpdateLightCommandHandler(ILightRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateLightCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Light Not Found.");

            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
