using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingIEDs
{
    public class SoftDeleteDyeingIEDCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class SoftDeleteDyeingIEDCommandHandler : IRequestHandler<SoftDeleteDyeingIEDCommand, Response<int>>
    {
        private readonly IDyeingIEDRepository _repository;

        public SoftDeleteDyeingIEDCommandHandler(IDyeingIEDRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(SoftDeleteDyeingIEDCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DyeingIED Not Found (Id:{command.Id}).");
            entity.Deleted = true;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}