using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRTasks
{
    public class DeleteDyeingTBRTaskCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBRTaskCommandHandler : IRequestHandler<DeleteDyeingTBRTaskCommand, Response<int>>
    {
        private readonly IDyeingTBRTaskRepository _repository;

        public DeleteDyeingTBRTaskCommandHandler(IDyeingTBRTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBRTaskCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBRTask Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}