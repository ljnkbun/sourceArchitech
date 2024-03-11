using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingBodyTypes
{
    public class DeleteKnittingBodyTypeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteKnittingBodyTypeCommandHandler : IRequestHandler<DeleteKnittingBodyTypeCommand, Response<int>>
    {
        private readonly IKnittingBodyTypeRepository _repository;
        public DeleteKnittingBodyTypeCommandHandler(IKnittingBodyTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteKnittingBodyTypeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"KnittingBodyType Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
