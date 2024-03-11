using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.SpinningProcesses
{
    public class UpdateSpinningProcessCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSpinningProcessCommandHandler : IRequestHandler<UpdateSpinningProcessCommand, Response<int>>
    {
        private readonly ISpinningProcessRepository _repository;
        public UpdateSpinningProcessCommandHandler(ISpinningProcessRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSpinningProcessCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SpinningProcess Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
