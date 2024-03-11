using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleOutputs
{
    public class ApproveRequestArticleOutputCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }
        public DivisionType DivisionType { get; set; }
    }
    public class ApproveRequestArticleOutputCommandHandler : IRequestHandler<ApproveRequestArticleOutputCommand, Response<int>>
    {
        private readonly IRequestArticleOutputRepository _repository;
        public ApproveRequestArticleOutputCommandHandler(IRequestArticleOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(ApproveRequestArticleOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.RequestArticleOutputId);
            if (entity == null) return new($"RequestArticleOutput Not Found.");

            if (entity.Status != Status.Waiting) return new($"Approving failed. The Status is not Waiting");
            entity.Status = Status.Approved;
            await _repository.UpdateStatusApproveArticleAsync(entity, command.DivisionType);
            return new Response<int>(entity.Id);
        }
    }
}
