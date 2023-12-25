using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequests
{
    public class ChangeStatusDyeingTBRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public TBRequestStatus Status { get; set; }
    }

    public class ChangeStatusDyeingTBRequestCommandHandler : IRequestHandler<ChangeStatusDyeingTBRequestCommand, Response<int>>
    {
        private readonly IDyeingTBRequestRepository _repository;

        public ChangeStatusDyeingTBRequestCommandHandler(IDyeingTBRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(ChangeStatusDyeingTBRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity == null) throw new ApiException($"DyeingTBRequest Not Found.");
            entity.Status = command.Status;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}