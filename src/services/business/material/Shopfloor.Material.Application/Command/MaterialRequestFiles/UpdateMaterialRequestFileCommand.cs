using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.MaterialRequestFiles
{
    public class UpdateMaterialRequestFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public int MaterialRequestId { get; set; }

        public FileType FileType { get; set; }

        public string FileName { get; set; }

        public string Description { get; set; }

        public string FileId { get; set; }

        public bool IsActive { get; set; }
    }

    public class UpdateMaterialRequestFileCommandHandler : IRequestHandler<UpdateMaterialRequestFileCommand, Response<int>>
    {
        private readonly IMaterialRequestFileRepository _repository;

        public UpdateMaterialRequestFileCommandHandler(IMaterialRequestFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(UpdateMaterialRequestFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if(entity == null) return new($"MaterialRequestFile Not Found.");
            entity.FileId = command.FileId;
            entity.Description = command.Description;
            entity.FileName = command.FileName;
            entity.MaterialRequestId = command.MaterialRequestId;
            entity.FileType = command.FileType;
            entity.IsActive = command.IsActive;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}