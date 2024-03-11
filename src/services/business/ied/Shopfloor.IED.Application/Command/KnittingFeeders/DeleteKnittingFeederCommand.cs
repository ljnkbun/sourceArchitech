using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingFeeders
{
    public class DeleteKnittingFeederCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteKnittingFeederCommandHandler : IRequestHandler<DeleteKnittingFeederCommand, Response<int>>
    {
        private readonly IKnittingFeederRepository _repository;
        public DeleteKnittingFeederCommandHandler(IKnittingFeederRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteKnittingFeederCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"KnittingFeeder Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
