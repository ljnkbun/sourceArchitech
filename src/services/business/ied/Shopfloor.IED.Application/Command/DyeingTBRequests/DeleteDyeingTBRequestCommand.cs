using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequests
{
    public class DeleteDyeingTBRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBRequestCommandHandler : IRequestHandler<DeleteDyeingTBRequestCommand, Response<int>>
    {
        private readonly IDyeingTBRequestRepository _repository;

        public DeleteDyeingTBRequestCommandHandler(IDyeingTBRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBRequest Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}