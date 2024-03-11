using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingBorderStyles
{
    public class UpdateWeavingBorderStyleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateWeavingBorderStyleCommandHandler : IRequestHandler<UpdateWeavingBorderStyleCommand, Response<int>>
    {
        private readonly IWeavingBorderStyleRepository _repository;
        public UpdateWeavingBorderStyleCommandHandler(IWeavingBorderStyleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingBorderStyleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingBorderStyle Not Found.");

            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
