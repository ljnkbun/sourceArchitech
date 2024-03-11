using MediatR;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Models.Responses;

namespace Shopfloor.Planning.Application.Command.MergeSplitPORs
{
    public class DeleteMergeSplitPORDetailCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteMergeSplitPORDetailCommandHandler : IRequestHandler<DeleteMergeSplitPORDetailCommand, Response<int>>
    {
        private readonly IMergeSplitPorDetailRepostiry _repository;
        public DeleteMergeSplitPORDetailCommandHandler(IMergeSplitPorDetailRepostiry repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteMergeSplitPORDetailCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"MergeSplitPORDetail Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
