using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.ProcessTasks
{
    public class UpdateProcessTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateProcessTaskCommandHandler : IRequestHandler<UpdateProcessTaskCommand, Response<int>>
    {
        private readonly IProcessTaskRepository _repository;
        public UpdateProcessTaskCommandHandler(IProcessTaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateProcessTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"ProcessTasks Not Found.");

            entity.Code = command.Code;
            entity.Name = command.Name;
            entity.Order = command.Order;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
