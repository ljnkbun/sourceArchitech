using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.KnittingFiles
{
    public class UpdateKnittingFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int KnittingIEDId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateKnittingFileCommandHandler : IRequestHandler<UpdateKnittingFileCommand, Response<int>>
    {
        private readonly IKnittingFileRepository _repository;
        public UpdateKnittingFileCommandHandler(IKnittingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateKnittingFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"KnittingFile Not Found.");

            entity.KnittingIEDId = command.KnittingIEDId;
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
