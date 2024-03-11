using MediatR;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Inspection.Application.Command.FourPointsSystemDetails
{
    public class DeleteFourPointsSystemDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFourPointsSystemDetailCommandHandler : IRequestHandler<DeleteFourPointsSystemDetailCommand, Response<int>>
    {
        private readonly IFourPointsSystemDetailRepository _repository;
        public DeleteFourPointsSystemDetailCommandHandler(IFourPointsSystemDetailRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFourPointsSystemDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) throw new ApiException($"FourPointsSystemDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
