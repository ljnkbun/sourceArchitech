using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.Shades
{
    public class UpdateShadeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateShadeCommandHandler : IRequestHandler<UpdateShadeCommand, Response<int>>
    {
        private readonly IShadeRepository _repository;
        public UpdateShadeCommandHandler(IShadeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateShadeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"Shade Not Found.");

            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
