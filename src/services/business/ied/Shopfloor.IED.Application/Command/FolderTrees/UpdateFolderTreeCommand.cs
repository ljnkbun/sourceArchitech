using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.FolderTrees
{
    public class UpdateFolderTreeCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateFolderTreeCommandHandler : IRequestHandler<UpdateFolderTreeCommand, Response<int>>
    {
        private readonly IFolderTreeRepository _repository;
        public UpdateFolderTreeCommandHandler(IFolderTreeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateFolderTreeCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Folder Not Found.");

            entity.Name = command.Name;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
