using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFiles
{
    public class UpdateSewingFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int SewingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateSewingFileCommandHandler : IRequestHandler<UpdateSewingFileCommand, Response<int>>
    {
        private readonly ISewingFileRepository _repository;
        public UpdateSewingFileCommandHandler(ISewingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateSewingFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"SewingFile Not Found.");

            entity.SewingIEDId = command.SewingIEDId;
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
