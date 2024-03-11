using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingShrinkages
{
    public class DeleteKnittingShrinkageCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteKnittingShrinkageCommandHandler : IRequestHandler<DeleteKnittingShrinkageCommand, Response<int>>
    {
        private readonly IKnittingShrinkageRepository _repository;
        public DeleteKnittingShrinkageCommandHandler(IKnittingShrinkageRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteKnittingShrinkageCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"KnittingShrinkage Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
