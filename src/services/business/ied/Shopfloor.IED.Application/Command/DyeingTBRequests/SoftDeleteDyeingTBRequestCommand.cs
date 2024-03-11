using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRequests
{
    public class SoftDeleteDyeingTBRequestCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SoftDeleteDyeingTBRequestCommandHandler : IRequestHandler<SoftDeleteDyeingTBRequestCommand, Response<int>>
    {
        private readonly IDyeingTBRequestRepository _repository;

        public SoftDeleteDyeingTBRequestCommandHandler(IDyeingTBRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SoftDeleteDyeingTBRequestCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DyeingTBRequest Not Found (Id:{command.Id}).");
            entity.Deleted = true;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}