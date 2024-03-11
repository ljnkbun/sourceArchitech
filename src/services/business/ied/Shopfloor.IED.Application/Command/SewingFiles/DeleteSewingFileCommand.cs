using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.SewingFiles
{
    public class DeleteSewingFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteSewingFileCommandHandler : IRequestHandler<DeleteSewingFileCommand, Response<int>>
    {
        private readonly ISewingFileRepository _repository;
        public DeleteSewingFileCommandHandler(ISewingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteSewingFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"SewingFile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
