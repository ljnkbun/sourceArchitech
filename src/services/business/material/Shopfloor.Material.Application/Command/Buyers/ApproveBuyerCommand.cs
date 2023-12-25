using MediatR;

using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Domain.Interfaces;

namespace Shopfloor.Material.Application.Command.Buyers
{
    public class ApproveBuyerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class ApproveBuyerCommandHandler : IRequestHandler<ApproveBuyerCommand, Response<int>>
    {
        private readonly IBuyerRepository _repository;

        public ApproveBuyerCommandHandler(IBuyerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(ApproveBuyerCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"{typeof(Buyer).Name} Not Found (Id:{command.Id}).");
            entity.Status = Domain.Enums.ProcessStatus.Approved;
            entity.ReasonReject = null;
            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}