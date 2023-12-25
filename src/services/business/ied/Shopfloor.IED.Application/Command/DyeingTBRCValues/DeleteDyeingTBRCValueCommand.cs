using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingTBRCValues
{
    public class DeleteDyeingTBRCValueCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingTBRCValueCommandHandler : IRequestHandler<DeleteDyeingTBRCValueCommand, Response<int>>
    {
        private readonly IDyeingTBRCValueRepository _repository;

        public DeleteDyeingTBRCValueCommandHandler(IDyeingTBRCValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingTBRCValueCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"DyeingTBRCValue Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}