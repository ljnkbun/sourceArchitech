using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleOutputs
{
    public class RejectRequestArticleOutputCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }
        public DivisionType DivisionType { get; set; }
        public string RejectReason { get; set; }
    }
    public class RejectRequestArticleOutputCommandHandler : IRequestHandler<RejectRequestArticleOutputCommand, Response<int>>
    {
        private readonly IRequestArticleOutputRepository _repository;
        public RejectRequestArticleOutputCommandHandler(IRequestArticleOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(RejectRequestArticleOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.RequestArticleOutputId);
            if (entity == null) return new($"RequestArticleOutput Not Found.");

            if (entity.Status != Status.Waiting) return new($"Rejecting failed. The Status is not Waiting");
            entity.Status = Status.InProgress;
            await _repository.UpdateStatusRejectArticleAsync(entity, command.DivisionType, command.RejectReason);
            return new Response<int>(entity.Id);
        }
    }
}
