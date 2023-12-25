using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequestFiles
{
    public class DeleteDyeingTBRequestFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBRequestFileCommandHandler : IRequestHandler<DeleteDyeingTBRequestFileCommand, Response<int>>
    {
        private readonly IDyeingTBRequestFileRepository _repository;

        public DeleteDyeingTBRequestFileCommandHandler(IDyeingTBRequestFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBRequestFileCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBRequestFile Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}