using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingFiles
{
    public class DeleteDyeingFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteDyeingFileCommandHandler : IRequestHandler<DeleteDyeingFileCommand, Response<int>>
    {
        private readonly IDyeingFileRepository _repository;
        public DeleteDyeingFileCommandHandler(IDyeingFileRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteDyeingFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DyeingFile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
