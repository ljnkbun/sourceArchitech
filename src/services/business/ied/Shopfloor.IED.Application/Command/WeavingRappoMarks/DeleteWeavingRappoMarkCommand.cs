using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingRappoMarks
{
    public class DeleteWeavingRappoMarkCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteWeavingRappoMarkCommandHandler : IRequestHandler<DeleteWeavingRappoMarkCommand, Response<int>>
    {
        private readonly IWeavingRappoMarkRepository _repository;
        public DeleteWeavingRappoMarkCommandHandler(IWeavingRappoMarkRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteWeavingRappoMarkCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"WeavingRappoMark Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
