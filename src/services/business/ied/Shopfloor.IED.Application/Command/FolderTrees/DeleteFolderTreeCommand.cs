using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.FolderTrees
{
    public class DeleteFolderTreeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFolderTreeCommandHandler : IRequestHandler<DeleteFolderTreeCommand, Response<int>>
    {
        private readonly IFolderTreeRepository _repository;

        public DeleteFolderTreeCommandHandler(IFolderTreeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFolderTreeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Folder Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
