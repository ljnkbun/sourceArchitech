using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingShrinkages
{
    public class UpdateKnittingShrinkageCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingShrinkageCommandHandler : IRequestHandler<UpdateKnittingShrinkageCommand, Response<int>>
    {
        private readonly IKnittingShrinkageRepository _repository;
        public UpdateKnittingShrinkageCommandHandler(IKnittingShrinkageRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingShrinkageCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingShrinkage Not Found.");

            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
