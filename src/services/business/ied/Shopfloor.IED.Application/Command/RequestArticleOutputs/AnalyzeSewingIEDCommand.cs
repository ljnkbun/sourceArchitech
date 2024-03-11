using MediatR;
using Shopfloor.Core.Models.Responses;
using Shopfloor.IED.Domain.Enums;
using Shopfloor.IED.Domain.Interfaces;

namespace Shopfloor.IED.Application.Command.RequestArticleOutputs
{
    public class AnalyzeRequestArticleOutputCommand : IRequest<Response<int>>
    {
        public int RequestArticleOutputId { get; set; }
        public DivisionType DivisionType { get; set; }
    }
    public class AnalyzeRequestArticleOutputCommandHandler : IRequestHandler<AnalyzeRequestArticleOutputCommand, Response<int>>
    {
        private readonly IRequestArticleOutputRepository _repository;
        public AnalyzeRequestArticleOutputCommandHandler(IRequestArticleOutputRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(AnalyzeRequestArticleOutputCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.RequestArticleOutputId);
            if (entity == null) return new($"RequestArticleOutput Not Found.");

            if (entity.Status != Status.New) return new($"Analyzing failed. The Status is not New");
            entity.Status = Status.InProgress;
            await _repository.UpdateStatusAnalyzeArticleAsync(entity, command.DivisionType);
            return new Response<int>(entity.Id);
        }
    }
}
