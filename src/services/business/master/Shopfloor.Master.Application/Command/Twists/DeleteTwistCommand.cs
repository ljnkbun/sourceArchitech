using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Master.Domain.Interfaces;

namespace Shopfloor.Master.Application.Command.Twists
{
    public class DeleteTwistCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteTwistCommandHandler : IRequestHandler<DeleteTwistCommand, Response<int>>
    {
        private readonly ITwistRepository _repository;
        public DeleteTwistCommandHandler(ITwistRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteTwistCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Twist Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
