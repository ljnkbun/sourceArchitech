using MediatR;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.DyeingProcessChemicals
{
    public class DeleteDyeingProcessChemicalCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteDyeingProcessChemicalCommandHandler : IRequestHandler<DeleteDyeingProcessChemicalCommand, Response<int>>
    {
        private readonly IDyeingProcessChemicalRepository _repository;

        public DeleteDyeingProcessChemicalCommandHandler(IDyeingProcessChemicalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteDyeingProcessChemicalCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"DyeingProcessChemical Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}