using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.FPPOOutputDetails
{
    public class DeleteFPPOOutputDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFPPOOutputDetailCommandHandler : IRequestHandler<DeleteFPPOOutputDetailCommand, Response<int>>
    {
        private readonly IFPPOOutputDetailRepository _repository;
        public DeleteFPPOOutputDetailCommandHandler(IFPPOOutputDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFPPOOutputDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"FPPOOutputDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
