using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingGreiges
{
    public class DeleteKnittingGreigeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteKnittingGreigeCommandHandler : IRequestHandler<DeleteKnittingGreigeCommand, Response<int>>
    {
        private readonly IKnittingGreigeRepository _repository;
        public DeleteKnittingGreigeCommandHandler(IKnittingGreigeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteKnittingGreigeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"KnittingGreige Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
