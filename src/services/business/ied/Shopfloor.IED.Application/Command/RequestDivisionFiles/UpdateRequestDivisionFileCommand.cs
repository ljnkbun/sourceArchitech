using MediatR;
using Shopfloor.Core.Definations;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestDivisionFiles
{
    public class UpdateRequestDivisionFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int RequestDivisionId { get; set; }
        public FileType FileType { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public bool IsActive { set; get; }
    }
    public class UpdateRequestDivisionFileCommandHandler : IRequestHandler<UpdateRequestDivisionFileCommand, Response<int>>
    {
        private readonly IRequestDivisionFileRepository _repository;
        public UpdateRequestDivisionFileCommandHandler(IRequestDivisionFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateRequestDivisionFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) return new($"RequestDivisionFile Not Found.");

            entity.RequestDivisionId = command.RequestDivisionId;
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
