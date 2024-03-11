using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Production.Domain.Interfaces;

namespace Shopfloor.Production.Application.Command.FPPOOutputs
{
    public class DeleteFPPOOutputCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFPPOOutputCommandHandler : IRequestHandler<DeleteFPPOOutputCommand, Response<int>>
    {
        private readonly IFPPOOutputRepository _repository;
        public DeleteFPPOOutputCommandHandler(IFPPOOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteFPPOOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"FPPOOutput Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
