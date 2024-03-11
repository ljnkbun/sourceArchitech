using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingYarns
{
    public class DeleteKnittingYarnCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteKnittingYarnCommandHandler : IRequestHandler<DeleteKnittingYarnCommand, Response<int>>
    {
        private readonly IKnittingYarnRepository _repository;
        public DeleteKnittingYarnCommandHandler(IKnittingYarnRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteKnittingYarnCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"KnittingYarn Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
