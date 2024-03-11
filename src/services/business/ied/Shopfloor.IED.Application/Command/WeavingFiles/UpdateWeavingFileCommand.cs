using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.WeavingFiles
{
    public class UpdateWeavingFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int WeavingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateWeavingFileCommandHandler : IRequestHandler<UpdateWeavingFileCommand, Response<int>>
    {
        private readonly IWeavingFileRepository _repository;
        public UpdateWeavingFileCommandHandler(IWeavingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateWeavingFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"WeavingFile Not Found.");

            entity.WeavingIEDId = command.WeavingIEDId;
            entity.FileType = command.FileType;
            entity.FileName = command.FileName;
            entity.Description = command.Description;  
            entity.FileId = command.FileId;
            entity.IsActive = command.IsActive;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
