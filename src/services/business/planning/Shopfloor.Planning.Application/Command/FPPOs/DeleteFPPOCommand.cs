using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Planning.Domain.Interfaces;

namespace Shopfloor.Planning.Application.Command.FPPOs
{
    public class DeleteFPPOCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteFPPOCommandHandler : IRequestHandler<DeleteFPPOCommand, Response<int>>
    {
        private readonly IFPPORepository _repository;
        public DeleteFPPOCommandHandler(IFPPORepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteFPPOCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"FPPO Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
