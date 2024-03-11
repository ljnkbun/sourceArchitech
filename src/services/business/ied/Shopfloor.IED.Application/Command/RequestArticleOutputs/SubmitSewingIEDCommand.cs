using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleOutputs
{
    public class SubmitRequestArticleOutputCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }
        public DivisionType DivisionType { get; set; }
    }
    public class SubmitRequestArticleOutputCommandHandler : IRequestHandler<SubmitRequestArticleOutputCommand, Response<int>>
    {
        private readonly IRequestArticleOutputRepository _repository;
        public SubmitRequestArticleOutputCommandHandler(IRequestArticleOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(SubmitRequestArticleOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.RequestArticleOutputId);
            if (entity == null) return new($"RequestArticleOutput Not Found.");

            if (entity.Status != Status.InProgress) return new($"Submitting failed. The Status is not InProgress");
            entity.Status = Status.Waiting;
            await _repository.UpdateStatusSubmitArticleAsync(entity, command.DivisionType);
            return new Response<int>(entity.Id);
        }
    }
}
